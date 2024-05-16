// ConoverHomeInspections
// WorkUnit.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class Assignment
    {
        public Assignment()
        {
            RequestedServices = new HashSet<AssignmentTask>();
        }

        public int AssignmentId { get; set; }
        public Address? Location { get; set; }
        public int? EstimatedCompletionTimeInMins { get; set; }
        public int? CommuteTimeToLocationInMins { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public virtual ICollection<AssignmentTask> RequestedServices { get; set; }
    }
}