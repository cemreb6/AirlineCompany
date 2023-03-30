using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;

namespace AirlineCompany.Data.EntityFramework
{
    public class UserFlightRepository : Repository<UserFlight>, IUserFlightRepository
    {
        public bool isUserAssignedToFlight(int userId, int flightId)
        {
            using(var context = new DataContext())
            {
                try
                {
                    var userFlight = context.UserFlights.First(u => u.User_id == userId && u.Flight_id == flightId);
                    return userFlight != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
