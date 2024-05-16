// ConoverHomeInspections
// ClientProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using System.Net.Http.Json;

namespace ConoverHomeInspections.Client.Services
{
    public class ClientProductService : IProductService
    {
        private ILogger<ClientProductService> _logger;
        private readonly HttpClient _client;

        public ClientProductService(HttpClient client, ILogger<ClientProductService> logger)
        {
            _client = client;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<ServiceProduct[]> GetServicesAsync()
        {
            try
            {
                var services = await _client.GetFromJsonAsync<ServiceProduct[]>("api/v1/Services");
                _logger.LogInformation("Successfully got services...");
                return services!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get services...");
                return null!;
            }
        }
    }
}