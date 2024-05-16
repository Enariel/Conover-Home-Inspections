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
    /// <summary>
    /// Server side implementation of the product service.
    /// </summary>
    /// <remarks>
    /// This class is responsible for fetching the product data from the database.
    /// </remarks>
    public class ServerProductService : IProductService
    {
        /// <inheritdoc />
        public async Task<SiteGroup[]> GetSiteGroupsAsync()
        {
            await using var ctx = new ConfigDbContext();
            var groups = await ctx.Groups
                                  .Include(x=>x.Services
                                               .OrderBy(s=>s.Order))
                                  .ThenInclude(x=>x.Details.OrderBy(d=>d.Order))
                                  .OrderBy(g=>g.Order)
                                  .ToArrayAsync();
            return groups;
        }

        /// <inheritdoc />
        public async Task<SiteService[]> GetSiteServicesAsync()
        {
            await using var ctx = new ConfigDbContext();
            var services = await ctx.Services
                                    .Include(x=>x.Details
                                                 .OrderBy(d=>d.Order))
                                    .OrderBy(s=>s.Order)
                                    .ToArrayAsync();
            return services;
        }

        /// <inheritdoc />
        public async Task<SiteService[]> GetServicesByGroupIdAsync(int groupId)
        {
            await using var ctx = new ConfigDbContext();
            var services = await ctx.Services
                                    .Include(x=>x.Details
                                                 .OrderBy(d=>d.Order))
                                    .Where(s=>s.GroupId == groupId)
                                    .OrderBy(s=>s.Order)
                                    .ToArrayAsync();
            if (services.Length == 0)
                services = await ctx.Services
                                    .Include(x=>x.Details
                                                 .OrderBy(d=>d.Order))
                                    .Where(s=>s.GroupId == ctx.Services.Select(x=>x.GroupId).Max())
                                    .OrderBy(s=>s.Order)
                                    .ToArrayAsync();
            return services;
        }

        /// <inheritdoc />
        public async Task<SiteService> GetServiceById(int serviceId)
        {
            await using var ctx = new ConfigDbContext();
            var service = await ctx.Services
                                   .Include(x => x.Details
                                                  .OrderBy(d => d.Order))
                                   .Where(s => s.ServiceId == serviceId)
                                   .FirstOrDefaultAsync()
                          ?? await ctx.Services
                                      .Include(x => x.Details
                                                     .OrderBy(d => d.Order))
                                      .Where(x=>x.ServiceId == ctx.Services.Select(x=>x.ServiceId).Max())
                                      .FirstOrDefaultAsync();
            return service!;
        }
    }
}