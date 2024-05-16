// ConoverHomeInspections
// ServerProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;

namespace ConoverHomeInspections.Services
{
    public class ServerProductService : IProductService
    {
        // TODO: Implement database functionality.
        // private DbContext _ctx;

        /// <inheritdoc />
        public Task<ServiceProduct[]> GetServicesAsync()
        {
            return Task.FromResult(new ServiceProduct[]
                                   {
                                       new ServiceProduct
                                       {
                                           ServiceId = 0,
                                           ServiceName = "Service 1",
                                           Description = "This is service 1.",
                                           Price = 100,
                                           Details = new List<ProductDetail>()
                                       },
                                       new ServiceProduct
                                       {
                                           ServiceId = 1,
                                           ServiceName = "Service 2",
                                           Description = "This is service 2.",
                                           Price = 200,
                                           Details = new List<ProductDetail>()
                                       },
                                        new ServiceProduct
                                        {
                                             ServiceId = 2,
                                             ServiceName = "Service 3",
                                             Description = "This is service 3.",
                                             Price = 300,
                                             Details = new List<ProductDetail>()
                                        },
                                        new ServiceProduct
                                        {
                                            ServiceId = 3,
                                            ServiceName = "Service 4",
                                            Description = "This is service 4.",
                                            Price = 50,
                                            Details = new List<ProductDetail>()
                                        },
                                   });
        }
    }
}