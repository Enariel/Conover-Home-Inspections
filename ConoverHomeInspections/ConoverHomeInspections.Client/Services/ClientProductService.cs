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
        public async Task<List<ServiceGroupDTO>> GetGroupsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ServiceGroupDTO>>("api/v1/Services/Groups");
            return response;
        }

        /// <inheritdoc />
        public async Task<List<ServiceDTO>> GetServicesAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ServiceDTO>>("api/v1/Services");
            return response;
        }

        /// <inheritdoc />
        public async Task<List<ServiceDTO>> GetGroupServicesAsync(int groupId)
        {
            var response = await _client.GetFromJsonAsync<List<ServiceDTO>>($"api/v1/Services/ServiceGroup/{groupId}");
            return response;
        }

        /// <inheritdoc />
        public async Task<ServiceDTO> GetServiceById(int serviceId)
        {
            var response = await _client.GetFromJsonAsync<ServiceDTO>($"api/v1/Services/{serviceId}");
            return response;
        }
    }
} 