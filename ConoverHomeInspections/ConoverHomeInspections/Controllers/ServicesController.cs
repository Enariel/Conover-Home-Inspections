// ConoverHomeInspections
// ServicesController.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConoverHomeInspections.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IProductService _productService;

        public ServicesController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<SiteService[]>> GetServicesAsync()
        {
            var services = await _productService.GetSiteServicesAsync();
            return Ok(services);
        }

        [HttpGet("Groups")]
        public async Task<ActionResult<SiteService[]>> GetServiceGroupsAsync()
        {
            var groups = await _productService.GetSiteGroupsAsync();
            return Ok(groups);
        }

        [HttpGet("ServiceGroup/{groupId:int}")]
        public async Task<ActionResult<SiteService[]>> GetServicesByGroupIdAsync(int? groupId)
        {
            if (groupId <= 0)
                return BadRequest("Invalid Group Id");

            if (groupId == null)
                return BadRequest("Invalid Group Id");

            var services = await _productService.GetServicesByGroupIdAsync(groupId.Value);
            return Ok(services);
        }

        [HttpGet("Service/{serviceId}")]
        public async Task<ActionResult<SiteService>> GetServiceById(int? serviceId)
        {
            if (serviceId <= 0)
                return BadRequest("Invalid Service Id");
            if (serviceId == null)
                return BadRequest("Invalid Service Id");

            var service = await _productService.GetServiceById(serviceId.Value);
            return Ok(service);
        }
    }
}