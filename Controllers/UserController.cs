using AirlineCompany.Modals;
using AirlineCompany.Services;
using AirlineCompany.Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.Logic.Abstarct;

namespace AirlineCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager= userManager;  
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpModal modal)
        {
          var user=await _userManager.SignUp(modal);
            return Ok(user);
        }
    }
}
