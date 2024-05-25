// ConoverHomeInspections
// ClientContact.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using System.Text;

namespace ConoverHomeInspections.Shared
{
    public class ClientContact
    {
        public Guid ContactId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NamePrefix { get; set; }
        public string? NameSuffix { get; set; }
        public string? MiddleInitial { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PrefersEmail { get; set; } = true;
        public bool PrefersPhone { get; set; } = false;
        public bool PrefersText { get; set; } = false;
        public string? RealtorFirstName { get; set; }
        public string? RealtorLastName { get; set; }
        public string? RealtorEmail { get; set; }
        public string? RealtorPhone { get; set; }
        public int? ServiceId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? PreferredStart { get; set; }
        public DateTime? PreferredEnd { get; set; }
        public string? Notes { get; set; }
        public string? InspectionAddress { get; set; }
        public string? MailingAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public virtual SiteService? Service { get; set; }
        public virtual SiteGroup? Group { get; set; }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {ContactId}");
            sb.AppendLine($"EmailAddress: {EmailAddress}");
            sb.AppendLine($"Name: Prefix: {NamePrefix}, FirstName: {FirstName}, MiddleInitial: {MiddleInitial}, LastName: {LastName}, Suffix: {NameSuffix}");
            sb.AppendLine($"PhoneNumber: {PhoneNumber}");
            sb.AppendLine($"Preferences: Email: {PrefersEmail}, Phone: {PrefersPhone}, Text: {PrefersText}");
            sb.AppendLine($"Realtor Info: FirstName: {RealtorFirstName}, LastName: {RealtorLastName}, Email: {RealtorEmail}, Phone: {RealtorPhone}");
            sb.AppendLine($"ServiceId: {ServiceId}");
            sb.AppendLine($"GroupId: {GroupId}");
            sb.AppendLine($"Preferred timings: Start: {PreferredStart}, End: {PreferredEnd}");
            sb.AppendLine($"Notes: {Notes}");
            sb.AppendLine($"Addresses: Inspection: {InspectionAddress}, Mailing: {MailingAddress}");
            sb.AppendLine($"Dates: CreatedOn: {CreatedOn}, ModifiedOn: {ModifiedOn}, RemovedOn: {RemovedOn}");
            sb.AppendLine($"Service: {Service}");
            sb.AppendLine($"Group: {Group}");
            return sb.ToString();
        }
    }
}