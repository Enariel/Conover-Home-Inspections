// ConoverHomeInspections
// ClientContactDTO.cs
//  2024
// Oliver Conover
// Modified: 22-05-2024
using System.ComponentModel.DataAnnotations;

namespace ConoverHomeInspections.Shared
{
    public class ClientContactDTO
    {
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(128)]
        public string RealtorFirstName { get; set; }
        [MaxLength(128)]
        public string RealtorLastName { get; set; }
        [MaxLength(255)]
        public string RealtorEmail { get; set; }
        [MaxLength(10)]
        public string RealtorPhone { get; set; }
        public int? GroupId { get; set; }
        public int? ServiceId { get; set; }
        public string Message { get; set; }
        public AddressDTO MailingAddress { get; set; }
        public AddressDTO InspectionPropertyAddress { get; set; }
        public DateTime? InspectionDateWindowMin { get; set; }
        public DateTime? InspectionDateWindowMax { get; set; }
    }
}