// ConoverHomeInspections
// ClientProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using System.Net.Http.Json;

namespace ConoverHomeInspections.Client.Services
{
    /// <summary>
    /// Client side implementation of the product service.
    /// </summary>
    /// <remarks>
    /// This class is responsible for fetching the product data from the server via http requests.
    /// </remarks>
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
        public async Task<SiteGroup[]> GetSiteGroupsAsync()
        {
            try
            {
                var groups = await _client.GetFromJsonAsync<SiteGroup[]>("api/v1/Services/Groups");
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
        public async Task<SiteService[]> GetSiteServicesAsync()
        {
            try
            {
                var services = await _client.GetFromJsonAsync<SiteService[]>("api/v1/Services");
                _logger.LogInformation("Successfully got services...");
                return services!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get services...");
                return null!;
            }
        }

        /// <inheritdoc />
        public async Task<SiteService[]> GetServicesByGroupIdAsync(int groupId)
        {
            try
            {
                var services = await _client.GetFromJsonAsync<SiteService[]>("api/v1/Services/ServiceGroup/" + groupId);
                _logger.LogInformation("Successfully got service...");
                return services!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get service...");
                return null!;
            }
        }

        /// <inheritdoc />
        public async Task<SiteService> GetServiceById(int serviceId)
        {
            try
            {
                var service = await _client.GetFromJsonAsync<SiteService>("api/v1/Services/Service/" + serviceId);
                _logger.LogInformation("Successfully got service...");
                return service!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get service...");
                return null;
            }
        }
    }
}