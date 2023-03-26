using AirlineCompany.Modals;
using AirlineCompany.Services;
using AirlineCompany.Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpModal modal)
        {
            Repository<CompanyUser> userRepository = new Repository<CompanyUser>();
            var passwordSalt = PasswordHasherService.GenerateSalt();
            var passwordHash = PasswordHasherService.GenerateHash(modal.Password, passwordSalt);
            userRepository.Create(new CompanyUser {Email=modal.Email,Name=modal.Name,Surname=modal.Surname,token="",PasswordHash=passwordHash,PasswordSalt=passwordSalt });
            return Ok();
        }
    }
}
