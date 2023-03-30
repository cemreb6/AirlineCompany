using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Modals
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyTicketModal : ControllerBase
    {
        public DateTime date { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string fullName { get; set; }
    }
}
