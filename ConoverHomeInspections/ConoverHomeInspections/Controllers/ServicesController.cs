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
        public async Task<ActionResult<Service[]>> GetServicesAsync()
        {
            var services = await _productService.GetServicesAsync();
            return Ok(services);
        }
    }
}