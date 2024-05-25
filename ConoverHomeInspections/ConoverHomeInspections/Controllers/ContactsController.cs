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
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpPost("Contact")]
        public async Task<IActionResult> GetServicesAsync([FromBody] ClientContactDTO contact)
        {
            try
            {
                await _contactService.ProcessContactFormAsync(contact);
                return Ok(contact.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Request Exception: "
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.Message}"
                                 + $"\n-----------------------------------------------------"
                                 + $"\n{ex.StackTrace}");
                return BadRequest();
            }
        }
    }
}