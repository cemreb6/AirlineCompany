using AirlineCompany.Modals;

namespace AirlineCompany.Data.Abstract
{
    public interface IFlightRepository
    {
        public Task<List<Flight>> GetFlights(QueryTicketModal modal);
    }
}
