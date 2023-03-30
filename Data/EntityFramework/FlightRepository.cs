using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;

namespace AirlineCompany.Data.EntityFramework
{
    public class FlightRepository: Repository<Flight>, IFlightRepository
    {
    }
}
