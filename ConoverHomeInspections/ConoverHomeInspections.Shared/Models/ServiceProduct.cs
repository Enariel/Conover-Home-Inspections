// ConoverHomeInspections
// Service.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{

    public class ServiceProduct
    {
        public ServiceProduct()
        {
            Details = new HashSet<ProductDetail>();
        }

        public int ServiceId { get; set; }
        public int? GroupId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int EstimatedCompletionTimeInMins { get; set; }
        public ProductGroup? Group { get; set; }
        public ICollection<ProductDetail> Details { get; set; }
    }

}