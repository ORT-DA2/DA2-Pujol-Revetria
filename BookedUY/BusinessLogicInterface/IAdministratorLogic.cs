using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
        Administrator AddAdministrator(Administrator administrator);
        Administrator GetByEmailAndPassword(string email, string password);
        Administrator GetById(int id);
        IEnumerable<Administrator> GetAll();
        void Delete(Administrator administrator)
    }
}
