using AirlineCompany.Data.Abstract;
using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;

namespace AirlineCompany.Logic.AirlineCompanyManagers
{
    public class FlightManager : IFlightManager
    {
        private IFlightRepository _flightRepository;
        public FlightManager(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<LogicResponseDTO<List<Flight>>> GetFlights(QueryTicketModal modal)
        {
           var flights =await _flightRepository.GetFlights(modal);
            return new LogicResponseDTO<List<Flight>> { Data = flights, Success = flights.Count > 0, Message = "" };
        }
    }
}
