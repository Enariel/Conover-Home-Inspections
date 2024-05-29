// ConoverHomeInspections
// ServerContactService.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
using AutoMapper;
using ConoverHomeInspections.Data;
using ConoverHomeInspections.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConoverHomeInspections.Services
{
    public class ServerContactService : IContactService
    {
        private readonly ILogger<IContactService> _logger;
        private readonly IDbContextFactory<ConfigDbContext> _ctx;
        private readonly IConfiguration _configuration;

        public ServerContactService(ILogger<ServerContactService> logger, IDbContextFactory<ConfigDbContext> ctx, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _ctx = ctx;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo, CancellationToken token = default)
        {
            // Create new contact entry
            _logger.LogInformation($"Creating contact... ");
            var newContact = new ClientContact
                             {
                                 EmailAddress = contactInfo.EmailAddress.ToUpperInvariant(),
                                 FirstName = contactInfo.FirstName.ToUpperInvariant(),
                                 LastName = contactInfo.LastName.ToUpperInvariant(),
                                 NamePrefix = contactInfo.NamePrefix?.ToUpperInvariant(),
                                 NameSuffix = contactInfo.NameSuffix?.ToUpperInvariant(),
                                 MiddleInitial = contactInfo.MiddleInitial?.ToUpperInvariant(),
                                 PhoneNumber = contactInfo.PhoneNumber?.Replace(" ", ""),
                                 PrefersEmail = contactInfo.PrefersEmail,
                                 PrefersPhone = contactInfo.PrefersPhone,
                                 PrefersText = contactInfo.PrefersText,
                                 RealtorFirstName = contactInfo.RealtorFirstName?.ToUpperInvariant(),
                                 RealtorLastName = contactInfo.RealtorLastName?.ToUpperInvariant(),
                                 RealtorEmail = contactInfo.RealtorEmail?.ToUpperInvariant(),
                                 RealtorPhone = contactInfo.RealtorPhone?.Replace(" ", ""),
                                 ServiceId = contactInfo.ServiceId,
                                 GroupId = contactInfo.GroupId,
                                 PreferredStart = contactInfo.InspectionDateRange.Start,
                                 PreferredEnd = contactInfo.InspectionDateRange.End,
                                 Notes = contactInfo.Message,
                                 InspectionAddress = contactInfo.InspectionPropertyAddress?.ToString(),
                                 MailingAddress = contactInfo.MailingAddress?.ToString(),
                                 CreatedOn = DateTime.Now,
                             };
            try
            {
                await using (var dbContext = await _ctx.CreateDbContextAsync(token))
                {
                    dbContext.ClientContacts.Add(newContact);
                    await dbContext.SaveChangesAsync(token);
                }
                _logger.LogInformation($"Contact form processed successfully!"
                                       + $"\n{newContact.ToString()}");

                MailTemplate clientTemplate;// template for the client
                MailTemplate detailTemplate;// template for dad
                ClientContact clientData;// client data
                await using (var dbContext = await _ctx.CreateDbContextAsync(token))
                {
                    clientData = await dbContext.ClientContacts
                                                .Include(x => x.Group)
                                                .Include(x => x.Service)
                                                .FirstOrDefaultAsync(x => x.ContactId == newContact.ContactId);
                    clientTemplate = await dbContext.EmailTemplates.FirstOrDefaultAsync(x => x.TemplateName == "ClientConfirmation");
                    detailTemplate = await dbContext.EmailTemplates.FirstOrDefaultAsync(x => x.TemplateName == "NewContact");

                }
                if (clientTemplate == null)
                {
                    _logger.LogWarning("Client Mail Template not found!");
                    return;
                }
                if (detailTemplate == null)
                {
                    _logger.LogWarning("Detail Mail Template not found!");
                }
                if (clientData == null)
                {
                    _logger.LogWarning("Client data not found!");
                    return;
                }

                await CreateClientEmailAsync(clientData, clientTemplate);
                _logger.LogInformation("Send client confirmation email...");
                await CreateDetailEmailAsync(clientData, detailTemplate);
                _logger.LogInformation("Send detail contact email...");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: "
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.Message}"
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.StackTrace}");
            }
        }

        private async Task SendEmailAsync(string to, string subject, string body, string cc)
        {
            var username = _configuration.GetSection("SMTPUsername").Value;
            var password = _configuration.GetSection("SMTPPassword").Value;
            MailAddress toEmail = new MailAddress(to);
            MailAddress fromEmail = new MailAddress("no-reply.conoverhomeinspections@outlook.com");
            MailMessage mail = new MailMessage(fromEmail, toEmail);
            if (!string.IsNullOrEmpty(cc))
            {
                var ccEmail = new MailAddress(cc);
                mail.CC.Add(ccEmail);
            }
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(username.ToString(), password.ToString());
            smtpClient.EnableSsl = true;
            _logger.LogWarning($"Sending email to: {to} | {cc}");
            await smtpClient.SendMailAsync(mail);
            _logger.LogInformation($"Email sent.");
        }

        private async Task CreateClientEmailAsync(ClientContact newContact, MailTemplate clientTemplate)
        {
            var body = clientTemplate.Body;
            var replaceDict = new Dictionary<string, string>();
            replaceDict.Add("{{CLIENTID}}", $"{newContact?.ContactId}");
            replaceDict.Add("{{CLIENTNAME}}", $"{newContact.FirstName}");
            replaceDict.Add("{{INSPECTIONADDRESS}}", $"{newContact.InspectionAddress}");
            replaceDict.Add("{{INSPECTIONDATE}}", new StringBuilder().Append(newContact.PreferredStart?.ToLongDateString()).Append(" thru ").Append(newContact.PreferredEnd?.ToLongDateString()).ToString());

            foreach (var key in replaceDict.Keys)
            {
                var replace = body.Replace(key, replaceDict[key]);
                body = replace;
            }

            _logger.LogInformation("Sending Client Information..."
                                   + "\n\tBODY:"
                                   + $"\n\t{body}");

            await SendEmailAsync(newContact.EmailAddress, clientTemplate.Subject, body, null);
        }

        private async Task CreateDetailEmailAsync(ClientContact newContact, MailTemplate detailTemplate)
        {
            var body = detailTemplate.Body;
            var replaceDict = new Dictionary<string, string>();
            replaceDict.Add("{{CLIENTID}}", $"{newContact?.ContactId}");
            replaceDict.Add("{{CLIENTNAME}}", $"{newContact.FirstName} {newContact.LastName}");
            replaceDict.Add("{{CLIENTEMAIL}}", $"{newContact.EmailAddress}");
            replaceDict.Add("{{CLIENTPHONE}}", $"{newContact?.PhoneNumber}");
            replaceDict.Add("{{CLIENTADDRESS}}", $"{newContact?.MailingAddress}");
            replaceDict.Add("{{ALLOWEMAIL}}", $"{(newContact.PrefersEmail ? "Yes" : "No")}");
            replaceDict.Add("{{ALLOWPHONE}}", $"{(newContact.PrefersPhone ? "Yes" : "No")}");
            replaceDict.Add("{{ALLOWTEXT}}", $"{(newContact.PrefersText ? "Yes" : "No")}");
            replaceDict.Add("{{CLIENTNOTES}}", $"{newContact?.Notes}");
            replaceDict.Add("{{GROUP}}", $"{(string.IsNullOrEmpty(newContact?.Group?.GroupName) ? "" : newContact?.Group?.GroupName)}");
            replaceDict.Add("{{SERVICE}}", $"{(string.IsNullOrEmpty(newContact?.Service?.ServiceName) ? "" : newContact?.Service?.ServiceName)}");
            replaceDict.Add("{{STARTDATE}}", $"{newContact.PreferredStart?.ToLongDateString()}");
            replaceDict.Add("{{ENDDATE}}", $"{newContact.PreferredEnd?.ToLongDateString()}");
            replaceDict.Add("{{PROPERTYADDRESS}}", $"{newContact.InspectionAddress}");
            replaceDict.Add("{{COST}}", $"{newContact?.Service?.Price:C2}");
            replaceDict.Add("{{TIME}}", $"{new TimeSpan(0, 0, newContact?.Service?.EstimatedCompletionTimeInMins ?? 0, 0).TotalHours:F2} hrs");
            replaceDict.Add("{{REALTORFIRST}}", newContact.RealtorFirstName);
            replaceDict.Add("{{REALTORLAST}}", newContact.RealtorLastName);
            replaceDict.Add("{{REALTOREMAIL}}", newContact.RealtorEmail);
            replaceDict.Add("{{REALTORPHONE}}", newContact.RealtorPhone);

            foreach (var key in replaceDict.Keys)
            {
                var replace = body.Replace(key, replaceDict[key]);
                body = replace;
            }

            _logger.LogInformation("Sending Detailed Client Information..."
                                   + "\n\tBODY:"
                                   + $"\n\t{body}");

            await SendEmailAsync("conoverhomeinspections@outlook.com", detailTemplate.Subject, body, "fuchsfarbeart@outlook.com");
        }
    }
}