// ConoverHomeInspections
// ClientContact.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ClientContact
    {
        public string? NamePrefix { get; set; }
        public required string FirstName { get; set; }
        public char? MiddleInitial { get; set; }
        public required string LastName { get; set; }
        public string? NameSuffix { get; set; }
        public string? EmailAddress { get; set; }
        public bool PrefersEmail { get; set; } = true;
        public string? PhoneNumber { get; set; }
        public bool PrefersPhone { get; set; } = false;
        public bool PrefersText { get; set; } = false;
        public DateRange[]? PreferredContactTimes { get; set; }
        public Address InspectionAddress { get; set; }
        public SiteService[] RequestedServices { get; set; } = [];
        public string? Notes { get; set; }
    }
}