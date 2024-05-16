// ConoverHomeInspections
// ContactsController.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConoverHomeInspections.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        [HttpPost("Contact")]
        public async Task<IActionResult> GetServicesAsync([FromBody] ClientContact contact)
        {
            // TODO: Validate contact form
            
            //TODO: Email dad the contact form with options to reply to the client, or accept the booking as it is.
            
            return Ok(ModelState);
        }
    }
}