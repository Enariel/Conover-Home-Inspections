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
        public async Task<ProductGroup[]> GetServiceGroupsAsync()
        {
            try
            {
                var groups = await _client.GetFromJsonAsync<ProductGroup[]>("api/v1/Services/Groups");
                _logger.LogInformation("Successfully got groups...");
                return groups!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get services...");
                return null!;
            }
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