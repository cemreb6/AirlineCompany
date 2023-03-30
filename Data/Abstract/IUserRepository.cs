using AirlineCompany.Modals;

namespace AirlineCompany.Data.Abstract
{
    public interface IUserRepository:IRepository<CompanyUser>
    {
        public CompanyUser? GetUserByEmail(string email);
    }
}
