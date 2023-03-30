using AirlineCompany.Data.Abstract;
using AirlineCompany.Modals;
using System.IdentityModel.Tokens.Jwt;

namespace AirlineCompany.Data.EntityFramework
{
    public class UserRepository : Repository<CompanyUser>, IUserRepository
    {
        public CompanyUser? GetUserByUsername(string email)
        {
           using(var context=new DataContext())
            {
                try
                {
                    var user=context.Users.Single(u=>u.Username== email);
                    return user;
                }catch(Exception)
                {
                    return null;
                }
            }
        }
        public void AddToken(JwtSecurityToken token, int id)
        {
            using (var context = new DataContext())
            {
                var user = context.Users.Single(u => u.Id == id);
                user.token = new JwtSecurityTokenHandler().WriteToken(token);
                context.Update(user);
                context.SaveChanges();
            }
        }
        public bool CheckToken(string token, int id)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var user = context.Users.Single(u => u.Id == id && u.token == token);
                    return user != null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}
