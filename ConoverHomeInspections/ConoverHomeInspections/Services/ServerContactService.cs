// ConoverHomeInspections
// ServerContactService.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
using ConoverHomeInspections.Shared;

namespace ConoverHomeInspections.Services
{
    public class ServerContactService : IContactService
    {
        private readonly ILogger<IContactService> _logger;

        public ServerContactService(ILogger<ServerContactService> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task SendContactFormAsync(ClientContactDTO contactInfo)
        {
            await Task.CompletedTask;
        }
    }
}