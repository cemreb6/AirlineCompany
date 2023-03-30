using AirlineCompany.Data.Abstract;
using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;
using AirlineCompany.Services;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Data.EntityFramework
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {

        public async Task<List<Flight>>? GetFlights(QueryTicketModal modal)
        {
            using (var context = new DataContext())
            {
                var filter = new PaginationService(modal.pageNumber, modal.pageSize);

                var pagedData = await context.Flights
                    .Where(flight => flight.Date == modal.Date && flight.Departure == modal.from && flight.Destination == modal.to && flight.AvailableSeats >= modal.peopleCount)
                    .Skip((filter.minNumber - 1) * filter.maxNumber)
                    .Take(filter.maxNumber)
                    .ToListAsync();

                return pagedData;

            }
        }

        public async Task<Flight>? UpdateFlightPassengers(int id)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var flight = context.Flights.Find(id);
                    if (flight != null)
                    {
                        if (flight.AvailableSeats >= 1)
                        {
                            flight.AvailableSeats = flight.AvailableSeats - 1;
                            context.Flights.Update(flight);
                            await context.SaveChangesAsync();
                        }
                    }
                    return flight;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public Flight? GetFlightFromFlightNo(string flightNo)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var flight = context.Flights.First(f => f.FlightNo == flightNo);
                    return flight;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
