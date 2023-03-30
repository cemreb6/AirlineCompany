using AirlineCompany.Modals;

namespace AirlineCompany.Logic.Abstarct
{
    public interface IUserManager
    {
        public Task<LogicResponseDTO<CompanyUser>> SignUp(SignUpModal modal);
    }
}
