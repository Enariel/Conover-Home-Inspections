// ConoverHomeInspections
// IProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    public interface IProductService
    {
        public Task<Service[]> GetServicesAsync();
    }
}