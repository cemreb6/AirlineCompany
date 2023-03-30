using AirlineCompany.Data.Abstract;
using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;

namespace AirlineCompany.Logic.AirlineCompanyManagers
{
    public class UserFlightManager : IUserFlightManager
    {
        private IUserFlightRepository _repository;
        public UserFlightManager(IUserFlightRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserFlight> BuyTicket(UserFlight userFlight)
        {
            var createdUserFlight=await _repository.Create(userFlight);
            return createdUserFlight;
        }
    }
}
