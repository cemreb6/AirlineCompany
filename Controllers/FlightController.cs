using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FlightController : ControllerBase
    {

        private IFlightManager _flightManager;
        public FlightController(IFlightManager flightManager)
        {
            _flightManager= flightManager;
        }
        [HttpPost,Authorize]
        public IActionResult BuyTicket([FromBody] BuyTicketModal modal)
        {
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTickets([FromQuery]QueryTicketModal modal)
        {
            var resp = await _flightManager.GetFlights(modal);
            return Ok(resp);
        }
    }
}
