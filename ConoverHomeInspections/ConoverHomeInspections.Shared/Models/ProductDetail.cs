// ConoverHomeInspections
// ServiceDetail.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ProductDetail
    {
        public int ServiceId { get; set; }
        public int DetailId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public ServiceProduct? Service { get; set; }
    }
}