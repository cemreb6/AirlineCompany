using AirlineCompany.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Flight : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public IActionResult BuyTicket([FromBody] BuyTicketModal modal)
        {
            return Ok();
        }
    }
}
