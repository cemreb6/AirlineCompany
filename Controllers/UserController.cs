using AirlineCompany.Modals;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.Logic.Abstarct;

namespace AirlineCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
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

        [HttpPost]
        public IActionResult SignIn([FromBody] SignInModal modal)
        {
            var user =  _userManager.SignIn(modal);
            return Ok(user);
        }
    }
}
