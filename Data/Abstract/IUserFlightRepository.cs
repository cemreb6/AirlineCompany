using AirlineCompany.Modals;

namespace AirlineCompany.Data.Abstract
{
    public interface IUserFlightRepository : IRepository<UserFlight>
    {

        public bool isUserAssignedToFlight(int userId, int flightId);
    }
}
