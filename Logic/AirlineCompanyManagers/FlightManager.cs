using AirlineCompany.Data.Abstract;
using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;

namespace AirlineCompany.Logic.AirlineCompanyManagers
{
    public class FlightManager : IFlightManager
    {
        private IUserFlightManager _userFlightManager;
        private IUserManager _userManager;
        private IFlightRepository _flightRepository;
        public FlightManager(IFlightRepository flightRepository, IUserFlightManager userFlightManager, IUserManager userManager)
        {
            _flightRepository = flightRepository;
            _userFlightManager = userFlightManager;
            _userManager = userManager;
        }

        public async Task<LogicResponseDTO<List<Flight>>> GetFlights(QueryTicketModal modal)
        {
           var flights =await _flightRepository.GetFlights(modal);
            return new LogicResponseDTO<List<Flight>> { Data = flights, Success = flights.Count > 0, Message = "" };
        }

        public async Task<LogicResponseDTO<string>> BuyTicket(BuyTicketModal modal,string token)
        {
            var flight = _flightRepository.GetFlightFromFlightNo(modal.flightNo);
            var user = _userManager.GetUserFromToken(token);
            if(flight !=null && user != null)
            {
                var createdUserFlight = await _userFlightManager.BuyTicket(new UserFlight { Flight_id=flight.Id,User_id=user.Id,PassengerFullName=modal.fullName});
                if(createdUserFlight !=null && createdUserFlight.Id > 0)
                {
                    var flightResponse=await _flightRepository.UpdateFlightPassengers(flight.Id);
                    if(flightResponse !=null && flightResponse.AvailableSeats< flight.AvailableSeats)
                    {
                        return new LogicResponseDTO<string> { Data = null, Message = "User assigned to flight successfully.", Success = true };
                    }
                    return new LogicResponseDTO<string> { Data = null, Message = "Available seat count update failed!", Success = false };
                }
                else
                {
                    return new LogicResponseDTO<string> { Data = null, Message = "User cannot be assigned to flight.", Success = false };
                }
            }
            else if (flight == null)
            {
                return new LogicResponseDTO<string> { Data = null, Message = "Flight not found!", Success = false };
            }
            return new LogicResponseDTO<string> { Data = null, Message = "User not found!", Success = false };
        }
    }
}
