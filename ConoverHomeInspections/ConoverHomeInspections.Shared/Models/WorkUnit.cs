// ConoverHomeInspections
// WorkUnit.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class WorkUnit
    {
        public int WorkOrderId { get; set; }
        public Address? Location { get; set; }
        public int? EstimatedCompletionTimeInMins { get; set; }
        public int? CommuteTimeToLocationInMins { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public ServiceProduct[]? Services { get; set; }
    }
}