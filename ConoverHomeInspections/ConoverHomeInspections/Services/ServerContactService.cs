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
        private readonly IProductService _productService;
        private readonly IDbContextFactory<ConfigDbContext> _ctx;
        private readonly IMapper _mapper;

        public ServerContactService(ILogger<ServerContactService> logger, IDbContextFactory<ConfigDbContext> ctx, IMapper mapper, IProductService productService)
        {
            _logger = logger;
            _ctx = ctx;
            _mapper = mapper;
            _productService = productService;
        }

        /// <inheritdoc />
        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo)
        {
            // Create new contact entry
            var newContact = _mapper.Map(contactInfo, new ClientContact());
            newContact.CreatedOn = DateTime.Now;
            _logger.LogInformation($"Creating contact: "
                                   + $"\n{newContact.ToString()}");
            try
            {
                await using (var dbContext = await _ctx.CreateDbContextAsync())
                {
                    dbContext.ClientContacts.Add(newContact);
                    await dbContext.SaveChangesAsync();
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
    }
}