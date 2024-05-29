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
                try
                {

                    await CreateConfirmationEmailAsync(newContact);
                    await CreateClientConfirmationEmailAsync(newContact);
                    _logger.LogInformation($"Sent emails!"
                                           + $"\n{newContact.ToString()}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Email Exception: "
                                     + $"\n-----------------------------------------------------"
                                     + $"\n{ex.Message}"
                                     + $"\n-----------------------------------------------------"
                                     + $"\n{ex.StackTrace}\n"
                                     + $"{ex.InnerException}");
                }
            }
            catch (DbException ex)
            {
                _logger.LogError($"Db Exception: "
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.Message}"
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.StackTrace}");
            }
            await Task.CompletedTask;
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
            await smtpClient.SendMailAsync(mail);
        }

        private async Task CreateClientConfirmationEmailAsync(ClientContact newContact)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>Client Confirmation</h3>");
            sb.AppendLine($"<p>Dear, {newContact.FirstName}</p>");
            sb.AppendLine("<p>Thank you, for contacting Conover Home Inspections.</p>");
            sb.AppendLine($"<p>"
                          + $"You have requested for an inspection between the dates: {newContact.PreferredStart?.ToLongDateString()} and {newContact.PreferredEnd?.ToLongDateString()}. "
                          + $"You will be contacted shortly in regards to your desired inspection. If you do not hear back within 3 business days, feel free to reach out directly. "
                          + $"</p>");
            sb.AppendLine("<br></br>");
            sb.AppendLine("<p>Thank you,</p>");
            sb.AppendLine("<p>Brian Conover</p>");
            sb.AppendLine("<p>Conover Home Inspections</p>");
            var body = sb.ToString();
            await SendEmailAsync(newContact.EmailAddress, "Conover Home Inspections - Confirmation", body, null);
        }

        private async Task CreateConfirmationEmailAsync(ClientContact newContact)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<style type=\"text/css\">.tg  {border-collapse:collapse;border-spacing:0;margin:0px auto;}.tg td{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px; overflow:hidden;padding:10px 5px;word-break:normal;}.tg th{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;font-weight:normal;overflow:hidden;padding:10px 5px;word-break:normal;}.tg .tg-0lax{text-align:left;vertical-align:top}</style>");
            sb.AppendLine("<h3>New Client Contact Request</h3>");
            sb.AppendLine("<h4>Client Information: </h4>");
            sb.AppendLine("<table class=\"tg\">");
            sb.AppendLine("<thead>"
                          + "<tr>"
                          + "<th class=\"tg-0lax\">Client Name</th>"
                          + "<th class=\"tg-0lax\">Contact Email</th>"
                          + "<th class=\"tg-0lax\">Contact Phone</th>"
                          + "<th class=\"tg-0lax\">Mailing Address</th>"
                          + "<th class=\"tg-0lax\">Notes</th>"
                          + "</tr>"
                          + "</thead>");
            sb.AppendLine("<tbody>"
                          + $"<td class=\"tg-0lax\">{newContact?.FirstName} {newContact?.LastName}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.EmailAddress}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.PhoneNumber}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.MailingAddress}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.Notes}</td>"
                          + "</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("<h4>Inspection Information: </h4>");
            sb.AppendLine("<table class=\"tg\">");
            sb.AppendLine("<thead>"
                          + "<tr>"
                          + "<th class=\"tg-0lax\">Inspection Type</th>"
                          + "<th class=\"tg-0lax\">Requested Start</th>"
                          + "<th class=\"tg-0lax\">Requested End</th>"
                          + "<th class=\"tg-0lax\">Inspection Address</th>"
                          + "</tr>"
                          + "</thead>");
            sb.AppendLine("<tbody>"
                          + $"<td class=\"tg-0lax\">{newContact?.Service?.ServiceName ?? newContact?.Group?.GroupName ?? "N/A"}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.PreferredStart?.ToLongDateString()}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.PreferredEnd?.ToLongDateString()}</td>"
                          + $"<td class=\"tg-0lax\">{newContact?.InspectionAddress}</td>"
                          + "</tbody>");
            sb.AppendLine("</table>");
            if (!string.IsNullOrEmpty(newContact?.RealtorFirstName) || !string.IsNullOrEmpty(newContact?.RealtorLastName))
            {
                sb.AppendLine("<h4>Realtor Information: </h4>");
                sb.AppendLine("<table class=\"tg\">");
                sb.AppendLine("<thead>"
                              + "<tr>"
                              + "<th class=\"tg-0lax\">Realtor Name</th>"
                              + "<th class=\"tg-0lax\">Realtor Email</th>"
                              + "<th class=\"tg-0lax\">Realtor Phone</th>"
                              + "</tr>"
                              + "</thead>");
                sb.AppendLine("<tbody>"
                              + $"<td class=\"tg-0lax\">{newContact?.RealtorFirstName} {newContact?.RealtorLastName}</td>"
                              + $"<td class=\"tg-0lax\">{newContact?.RealtorEmail}</td>"
                              + $"<td class=\"tg-0lax\">{newContact?.RealtorPhone}</td>"
                              + "</tbody>");
                sb.AppendLine("</table>");
            }
            var body = sb.ToString();
            await SendEmailAsync("conoverhomeinspections@outlook.com", "Conover Home Inspections - New Client Request", body, null);
        }
    }
}