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

namespace ConoverHomeInspections.Services
{
    public class ServerContactService : IContactService
    {
        private readonly ILogger<IContactService> _logger;
        private readonly IDbContextFactory<ConfigDbContext> _ctx;
        private readonly IMapper _mapper;

        public ServerContactService(ILogger<ServerContactService> logger, IDbContextFactory<ConfigDbContext> ctx, IMapper mapper)
        {
            _logger = logger;
            _ctx = ctx;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo, CancellationToken token = default)
        {
            // Create new contact entry
            _logger.LogInformation($"Creating contact... ");
            var newContact = _mapper.Map(contactInfo, new ClientContact());
            newContact.CreatedOn = DateTime.Now;

            try
            {
                await using (var dbContext = await _ctx.CreateDbContextAsync(token))
                {
                    dbContext.ClientContacts.Add(newContact);
                    await dbContext.SaveChangesAsync(token);
                }
                _logger.LogInformation($"Contact form processed successfully!"
                                       + $"\n{newContact.ToString()}");
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
    }
}