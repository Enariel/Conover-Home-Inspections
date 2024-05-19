// ConoverHomeInspections
// ServiceDTO.cs
//  2024
// Oliver Conover
// Modified: 19-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ServiceDTO
    {
        public int ServiceId { get; set; }
        public int? GroupId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int EstimatedCompletionTimeInMins { get; set; }
        public int? Order { get; set; }
        public int? SKU { get; set; }
        public List<ServiceDetailDTO> Details { get; set; } = new List<ServiceDetailDTO>();
    }
}