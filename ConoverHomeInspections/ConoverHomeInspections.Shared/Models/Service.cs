// ConoverHomeInspections
// Service.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class Service
    {
        public Service()
        {
            Details = new HashSet<ServiceDetail>();
        }

        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<ServiceDetail> Details { get; set; }
    }

}