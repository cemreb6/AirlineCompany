using AirlineCompany.Data.Abstract;
using AirlineCompany.Logic.Abstarct;
using AirlineCompany.Modals;
using AirlineCompany.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AirlineCompany.Logic.AirlineCompanyManagers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<LogicResponseDTO<CompanyUser>> SignUp(SignUpModal modal)
        {
            var user = _userRepository.GetUserByEmail(modal.Email);
            if (user == null)
            {
                var passwordSalt = PasswordHasherService.GenerateSalt();
                var passwordHash = PasswordHasherService.GenerateHash(modal.Password, passwordSalt);
                var newuser = new CompanyUser
                {
                    Email = modal.Email,
                    Name = modal.Name,
                    Surname = modal.Surname,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                newuser = CreateToken(newuser);

                var createdUser = await _userRepository.Create(newuser);
                createdUser.PasswordHash = new byte[1];
                createdUser.PasswordSalt = new byte[1];
                if (createdUser != null)
                    return new LogicResponseDTO<CompanyUser> { Data = createdUser, Success = createdUser != null, Message = "Sign Up opearation completed successfully." };
            }
            else
            {
                return new LogicResponseDTO<CompanyUser> { Data = null, Success = false, Message = "The email exist.Please sign in." };
            }
            return new LogicResponseDTO<CompanyUser> { Data = null, Success = false, Message = "Unexpected error occured." };
        }

        public LogicResponseDTO<CompanyUser> SignIn(SignInModal modal)
        {
            var user = _userRepository.GetUserByEmail(modal.Email);
            if (user != null)
            {
                var isPasswordValid = PasswordHasherService.VerifyPassword(modal.Password, user.PasswordSalt, user.PasswordHash);
                user.PasswordHash = new byte[0];
                user.PasswordSalt = new byte[0];
                return new LogicResponseDTO<CompanyUser>
                {
                    Data = isPasswordValid ? user : null,
                    Success = isPasswordValid,
                    Message = isPasswordValid ? "Sign in operation completed successfully."
                    :
                    "Sign in operation failed!"
                };
            }
            else
            {
                return new LogicResponseDTO<CompanyUser> { Data = null, Success = false, Message = "There is no such user!" };
            }
        }
        private CompanyUser CreateToken(CompanyUser user)
        {
            var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Email, user.Email),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var token = GetToken(authClaims);
            user.token = new JwtSecurityTokenHandler().WriteToken(token);
            return user;
        }
        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMonths(12),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

    }
}
