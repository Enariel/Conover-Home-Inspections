// ConoverHomeInspections
// ServerProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using AutoMapper;
using ConoverHomeInspections.Data;
using ConoverHomeInspections.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IMapper _map;
        private readonly IDbContextFactory<ConfigDbContext> _ctx;
        private readonly ILogger<IProductService> _logger;

        public ServerProductService(ILogger<ServerProductService> logger, IDbContextFactory<ConfigDbContext> ctx, IMapper map)
        {
            _logger = logger;
            _ctx = ctx;
            _map = map;
        }

        /// <inheritdoc />
        public async Task<List<ServiceGroupDTO>> GetGroupsAsync()
        {
            await using var ctx = await _ctx.CreateDbContextAsync();
            var groups = await ctx.Groups
                                   .OrderBy(x => x.Order)
                                   .Select(x => _map.Map<ServiceGroupDTO>(x))
                                   .ToListAsync();
            return groups;
        }

        /// <inheritdoc />
        public async Task<List<ServiceDTO>> GetServicesAsync()
        {
            await using var ctx = await _ctx.CreateDbContextAsync();
            var services = await ctx.Services
                                     .OrderBy(x => x.Order)
                                     .Include(x=>x.Details)
                                     .Select(x => _map.Map<ServiceDTO>(x))
                                     .ToListAsync();
            return services;
        }

        /// <inheritdoc />
        public async Task<List<ServiceDTO>> GetGroupServicesAsync(int groupId)
        {
            await using var ctx = await _ctx.CreateDbContextAsync();
            var services = await ctx.Services
                               .Where(x => x.GroupId == groupId)
                               .OrderBy(x => x.Order)
                               .Select(x => _map.Map<ServiceDTO>(x))
                               .ToListAsync();
            return services;
        }

        /// <inheritdoc />
        public async Task<ServiceDTO> GetServiceById(int serviceId)
        {
            await using var ctx = await _ctx.CreateDbContextAsync();
            var service = await ctx.Services
                                    .Where(x => x.ServiceId == serviceId)
                                    .Select(x => _map.Map<ServiceDTO>(x))
                                    .FirstOrDefaultAsync();
            return service;
        }
    }
}