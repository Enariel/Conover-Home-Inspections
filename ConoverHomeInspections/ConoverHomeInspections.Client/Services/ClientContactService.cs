// ConoverHomeInspections
// ClientContactService.cs
//  2024
// Oliver Conover
// Modified: 23-05-2024
using ConoverHomeInspections.Shared;
using MudBlazor;
using System.Net.Http.Json;

namespace ConoverHomeInspections.Client.Services
{
    /// <inheritdoc />
    public class ClientContactService : IContactService
    {
        private readonly ILogger<IContactService> _logger;
        private readonly HttpClient _client;
        private readonly ISnackbar _bar;

        public ClientContactService(ILogger<ClientContactService> logger, HttpClient client, ISnackbar bar)
        {
            _logger = logger;
            _client = client;
            _bar = bar;
        }

        public async Task ProcessContactFormAsync(ClientContactDTO contactInfo, CancellationToken token = default)
        {
            try
            {
                _logger.LogInformation($"Processing contact form: {contactInfo.ToString()}");
                var request = await _client.PostAsJsonAsync("api/v1/Contacts/Contact", contactInfo, token);
                if (!request.IsSuccessStatusCode)
                {
                    var requestData = await request.Content.ReadAsStringAsync(token);
                    _logger.LogError("Error processing request: "
                                     + $"\n{requestData}");
                }

                _bar.Add("Success!", Severity.Success);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error processing contact form: {ex.Message}");
                _bar.Add("Error processing request", Severity.Error);
            }
            finally
            {
                _logger.LogWarning("Finished processing contact form...");
                await Task.CompletedTask;
            }
        }
    }
}