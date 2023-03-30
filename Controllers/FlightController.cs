using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;
using AirlineCompany.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FlightController : ControllerBase
    {

        private IFlightManager _flightManager;
        public FlightController(IFlightManager flightManager)
        {
            _flightManager= flightManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTickets([FromQuery]QueryTicketModal modal)
        {
            var resp = await _flightManager.GetFlights(modal);
            return Ok(resp);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> BuyTicket([FromBody] BuyTicketModal modal)
        {
            var response = await _flightManager.BuyTicket(modal, TokenService.GetToken(Request));
            return Ok(response);
        }
    }
}
