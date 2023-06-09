﻿using AirlineCompany.Modals;

namespace AirlineCompany.Data.Abstract
{
    public interface IUserRepository:IRepository<CompanyUser>
    {
        public CompanyUser? GetUserByUsername(string username);

        public CompanyUser? GetUserByToken(string token);
    }
}
