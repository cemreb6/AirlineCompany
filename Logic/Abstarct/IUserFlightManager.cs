using AirlineCompany.Modals;

namespace AirlineCompany.Logic.Abstarct
{
    public interface IUserFlightManager
    {
        public Task<UserFlight> BuyTicket(UserFlight userFlight);

        public bool IsUserflightExist(int userId,int flightId);
    }
}
