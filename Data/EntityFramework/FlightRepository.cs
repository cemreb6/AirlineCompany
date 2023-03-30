using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;
using AirlineCompany.Services;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Data.EntityFramework
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public async Task<List<Flight>> GetFlights(QueryTicketModal modal)
        {
            using (var context =new DataContext())
            {
                var filter = new PaginationService(modal.pageNumber,modal.pageSize);
                var flights = new List<Flight>();

                var pagedData = await context.Flights
                    .Where(flight => flight.Date == modal.Date && flight.Departure == modal.from && flight.Destination == modal.to && flight.AvailableSeats >= modal.peopleCount)
                    .Skip((filter.minNumber - 1) * filter.maxNumber)
                    .Take(filter.maxNumber)
                    .ToListAsync();

                return flights;
            }
        }
    }
}
