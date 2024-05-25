// ConoverHomeInspections
// ClientContactService.cs
//  2024
// Oliver Conover
// Modified: 23-05-2024
using ConoverHomeInspections.Shared;

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

        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo)
        {
            try
            {
                _logger.LogInformation($"Processing contact form: {contactInfo.ToString()}");
                await Task.Delay(200);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error processing contact form: {ex.Message}");
            }
            finally
            {
                _logger.LogWarning("Finished processing contact form...");
                await Task.CompletedTask;
            }
        }
    }
}