// ConoverHomeInspections
// ServerProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Data;
using ConoverHomeInspections.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConoverHomeInspections.Services
{
    public class ServerProductService : IProductService
    {
        /// <inheritdoc />
        public async Task<ProductGroup[]> GetServiceGroupsAsync()
        {
            await using var ctx = new ConfigDbContext();
            var groups = await ctx.Groups.Include(x=>x.Services).ThenInclude(x=>x.Details).ToArrayAsync();
            return groups;
        }

        /// <inheritdoc />
        public async Task<ServiceProduct[]> GetServicesAsync()
        {
            await using var ctx = new ConfigDbContext();
            var services = await ctx.Services.ToArrayAsync();
            return services;
        }
    }
}