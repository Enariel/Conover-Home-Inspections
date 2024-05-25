// ConoverHomeInspections
// ContactsController.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConoverHomeInspections.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpPost("Contact")]
        public async Task<IActionResult> GetServicesAsync([FromBody] ClientContactDTO contact)
        {
            // TODO: Validate contact form
            
            //TODO: Email dad the contact form with options to reply to the client, or accept the booking as it is.

            var s = contact.ToString();
            _logger.LogInformation(s);
            return Ok(s);
        }
    }
}