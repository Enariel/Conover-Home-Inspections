// ConoverHomeInspections
// EmailMessage.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
using System.ComponentModel.DataAnnotations;

namespace ConoverHomeInspections.Shared
{
    public class EmailMessage
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}