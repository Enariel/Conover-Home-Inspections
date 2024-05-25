// ConoverHomeInspections
// ClientContactDTO.cs
//  2024
// Oliver Conover
// Modified: 22-05-2024
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConoverHomeInspections.Shared
{
    public class ClientContactDTO
    {
        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Email address is required for confirming inspection correspondences.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [MaxLength(10, ErrorMessage = "Phone number cannot be greater than 10 characters.")]
        public string Phone { get; set; }
        [MaxLength(128)]
        public string RealtorFirstName { get; set; }
        [MaxLength(128)]
        public string RealtorLastName { get; set; }
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Please enter a valid agency email address.")]
        public string RealtorEmail { get; set; }
        [MaxLength(10)]
        [Phone(ErrorMessage = "Please enter a valid agency phone number.")]
        public string RealtorPhone { get; set; }
        public int? GroupId { get; set; }
        public int? ServiceId { get; set; }
        public string Message { get; set; }
        public AddressDTO MailingAddress { get; set; } = new AddressDTO();
        public AddressDTO InspectionPropertyAddress { get; set; } = new AddressDTO();
        public DateRange InspectionDateRange { get; set; } = new DateRange();

        /// <inheritdoc />
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Client:"
                          + $"\n{FirstName} {LastName}");
            sb.AppendLine($"Email - {Email} | Phone - {Phone}");
            sb.AppendLine($"{MailingAddress.ToString()}");
            sb.AppendLine($"Realtor:"
                          + $"\n{RealtorFirstName} {RealtorLastName}");
            sb.AppendLine($"Phone - {Phone} | Email - {Email}");
            sb.AppendLine("Client Message:");
            sb.AppendLine($"{Message}");
            sb.AppendLine($"Inspection Info:");
            sb.AppendLine($"Service Requested | g-{GroupId} s-{ServiceId}");
            sb.AppendLine("Date Range | "
                          + $"{InspectionDateRange.Start.ToLongDateString()} thru"
                          + $"{InspectionDateRange.End.ToLongDateString()}");
            sb.AppendLine($"{InspectionPropertyAddress.ToString()}");
            return sb.ToString();
        }
    }
}