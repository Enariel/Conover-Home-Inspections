// ConoverHomeInspections
// ClientContactService.cs
//  2024
// Oliver Conover
// Modified: 23-05-2024
using ConoverHomeInspections.Shared;
using System.Net.Http.Json;

namespace ConoverHomeInspections.Client.Services
{
    /// <inheritdoc />
    public class ClientContactService : IContactService
    {
        private readonly ILogger<IContactService> _logger;
        private readonly HttpClient _client;

        public ClientContactService(ILogger<ClientContactService> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo, CancellationToken token = default)
        {
            _logger.LogInformation($"Processing contact form: {contactInfo.ToString()}");
            var request = await _client.PostAsJsonAsync("api/v1/Contacts/Contact", contactInfo, token);
            if (!request.IsSuccessStatusCode)
            {
                var requestData = await request.Content.ReadAsStringAsync(token);
                _logger.LogError("Error processing request: "
                                 + $"\n{requestData}");
            }
        }
    }
}