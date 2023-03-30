using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Modals
{
  
    public class BuyTicketModal
    {
        public DateTime date { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string flightNo { get; set; }
        public string fullName { get; set; }
    }
}
