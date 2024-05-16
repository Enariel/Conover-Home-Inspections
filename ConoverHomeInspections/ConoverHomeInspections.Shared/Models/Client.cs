// ConoverHomeInspections
// Client.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string? Email { get; set; }
        public string? Phone { get; set; }
        public required Address MailingAddress { get; set; }
        public Address? InspectionAddress { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<Assignment>? Assignments { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}