using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Administrator GetByEmail(string email);
    }
}
