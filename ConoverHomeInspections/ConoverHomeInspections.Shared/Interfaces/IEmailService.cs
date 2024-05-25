// ConoverHomeInspections
// IEmailService.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
namespace ConoverHomeInspections.Shared
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}