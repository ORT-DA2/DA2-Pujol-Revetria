using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
