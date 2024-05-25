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
            var name = $"{(string.IsNullOrEmpty(NamePrefix) ? NamePrefix.ToUpperInvariant() + ", " : "")}{FirstName.ToUpperInvariant()}, {(string.IsNullOrEmpty(MiddleInitial) ? "" : MiddleInitial.ToUpperInvariant().FirstOrDefault() + ", ")}{LastName.ToUpperInvariant()} {(string.IsNullOrEmpty(NameSuffix) ? "" : ", " + NameSuffix.ToUpperInvariant())}";
            sb.AppendLine($"Name: {name.ToUpperInvariant()}");
            sb.AppendLine($"Email: {EmailAddress.ToUpperInvariant()} | Phone : {PhoneNumber}");
            sb.AppendLine($"Address: "
                          + $"\n{MailingAddress.ToUpperInvariant()}");
            sb.AppendLine($"Preferences: Email - {PrefersEmail.ToString()} | Phone - {PrefersPhone.ToString()} | Text - {PrefersText.ToString()}");
            sb.AppendLine($"Realtor: {RealtorFirstName.ToUpperInvariant()} {RealtorLastName.ToUpperInvariant()}"
                          + $"\n, Email: {RealtorEmail.ToUpperInvariant()} | Phone: {RealtorPhone}");
            if (ServiceId.HasValue)
                sb.AppendLine($"ServiceId: {ServiceId}");
            if (GroupId.HasValue)
                sb.AppendLine($"GroupId: {GroupId}");
            sb.AppendLine($"Property: "
                          + $"\n{InspectionAddress.ToUpperInvariant()}");
            sb.AppendLine($"Request Dates: {PreferredStart?.ToLongDateString()} thru {PreferredEnd?.ToLongDateString()}");
            if (!string.IsNullOrEmpty(Notes))
                sb.AppendLine($"CLIENT MESSAGE:"
                              + $"\n\t {Notes}");
            return sb.ToString();
        }
    }
}