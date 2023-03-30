using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;

namespace AirlineCompany.Logic.Abstarct
{
    public interface IFlightManager
    {

        public Task<LogicResponseDTO<List<Flight>>> GetFlights(QueryTicketModal modal);
    }
}
