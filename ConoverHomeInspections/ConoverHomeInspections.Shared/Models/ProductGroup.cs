// ConoverHomeInspections
// ProductGroup.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ProductGroup
    {
        public ProductGroup()
        {
            Services = new HashSet<ServiceProduct>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }

        public ICollection<ServiceProduct> Services { get; set; }
    }

}