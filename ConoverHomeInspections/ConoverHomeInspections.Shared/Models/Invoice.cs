// ConoverHomeInspections
// Invoice.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid ClientId { get; set; }
        public int? AssignmentId { get; set; }
        public DateTime InvoiceCreateDate { get; set; }
        public DateTime? InvoiceDueDate { get; set; }
        public int? EstimatedTimeInMins { get; set; }
        public decimal EstimatedTimeInHours => Math.Round((decimal)(EstimatedTimeInMins ?? 60M / 60M)!, 2);
        public decimal? Deposit { get; set; }
        public decimal Total { get; set; } = 0.00M;
        public string? Notes { get; set; }
        public DateTime? DepositPaidOn { get; set; }
        public bool DepositPaid { get; set; } = false;
        public DateTime? TotalPaidOn { get; set; }
        public bool TotalPaid { get; set; } = false;
        public virtual Assignment? Assignment { get; set; }
        public virtual Client? Client { get; set; }
    }
}