// ConoverHomeInspections
// ServiceDetailDTO.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ServiceDetailDTO
    {
        public int ServiceId { get; set; }
        public int DetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
    }
}