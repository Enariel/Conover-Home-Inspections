// ConoverHomeInspections
// Service.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using System.Text.Json.Serialization;

namespace ConoverHomeInspections.Shared
{

    public class SiteService
    {
        public SiteService()
        {
            Details = new HashSet<ServiceDetail>();
            Task = new HashSet<AssignmentTask>();
        }

        public int ServiceId { get; set; }
        public int? GroupId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int EstimatedCompletionTimeInMins { get; set; }
        public int? Order { get; set; }
        public int? SKU { get; set; }
        public virtual SiteGroup? Group { get; set; }
        public virtual ICollection<ServiceDetail> Details { get; set; }
        public virtual ICollection<AssignmentTask> Task { get; set; }
    }

}