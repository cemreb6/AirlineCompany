using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;

namespace AirlineCompany.Data.EntityFramework
{
    public class UserRepository : Repository<CompanyUser>, IUserRepository
    {
        public CompanyUser? GetUserByUsername(string username)
        {
           using(var context=new DataContext())
            {
                try
                {
                    var user=context.Users.Single(u=>u.Username== username);
                    return user;
                }catch(Exception)
                {
                    return null;
                }
            }
        }

        public CompanyUser? GetUserByToken(string token)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var user = context.Users.Single(u => u.token == token);
                    return user;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
