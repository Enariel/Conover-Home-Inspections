// ConoverHomeInspections
// ClientContactService.cs
//  2024
// Oliver Conover
// Modified: 23-05-2024
using ConoverHomeInspections.Shared;

namespace ConoverHomeInspections.Client.Services
{
    /// <summary>
    /// A service designed to control the flow of client contacting the business.
    /// </summary>
    public class ClientContactService: IContactService
    {
        public async Task SendContactFormAsync(ClientContactDTO contactInfo)
        {
            await Task.CompletedTask;
        }
    }
}