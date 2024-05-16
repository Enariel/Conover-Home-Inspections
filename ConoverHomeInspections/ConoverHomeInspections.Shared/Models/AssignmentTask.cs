// ConoverHomeInspections
// WorkServices.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class AssignmentTask
    {
        public int AssignmentId { get; set; }
        public int ServiceId { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual SiteService Service { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}