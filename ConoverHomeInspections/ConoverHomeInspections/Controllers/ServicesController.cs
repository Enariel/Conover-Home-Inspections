// ConoverHomeInspections
// ServicesController.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConoverHomeInspections.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IProductService _productService;

        public ServicesController(IProductService productService, ILogger<ServicesController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServiceIndexAsync()
        {
            var services = await _productService.GetServicesAsync();
            if (services == null)
                return NoContent();

            return Ok(services);
        }

        [HttpGet("Groups")]
        public async Task<ActionResult<IEnumerable<ServiceGroupDTO>>> GetServiceGroupIndexAsync()
        {
            var groups = await _productService.GetGroupsAsync();
            if (groups == null)
                return NoContent();

            return Ok(groups);
        }

        [HttpGet("ServiceGroup/{groupId:int}")]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServicesByGroupIdAsync(int? groupId)
        {
            if (groupId <= 0)
                return BadRequest("Invalid Group Id");

            if (groupId == null)
                return BadRequest("Invalid Group Id");

            var services = await _productService.GetGroupServicesAsync(groupId.Value);
            if (services == null)
                return NoContent();

            return Ok(services);
        }

        [HttpGet("Service/{serviceId}")]
        public async Task<ActionResult<ServiceDTO>> GetServiceById(int? serviceId)
        {
            if (serviceId <= 0)
                return BadRequest("Invalid Service Id");
            if (serviceId == null)
                return BadRequest("Invalid Service Id");

            var service = await _productService.GetServiceById(serviceId.Value);
            if (service == null)
                return NoContent();

            return Ok(service);
        }
    }
}