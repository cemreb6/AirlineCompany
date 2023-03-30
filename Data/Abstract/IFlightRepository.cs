using AirlineCompany.Modals;

namespace AirlineCompany.Data.Abstract
{
    public interface IFlightRepository : IRepository<Flight>
    {
        public Task<List<Flight>>? GetFlights(QueryTicketModal modal);
        public Task<Flight>? UpdateFlightPassengers(int id);
        public Flight? GetFlightFromFlightNo(string flightNo);
    }
}
