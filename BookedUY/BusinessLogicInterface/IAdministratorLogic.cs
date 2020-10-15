using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
        Administrator AddAdministrator(Administrator administrator);

        Administrator GetByEmailAndPassword(string email, string password);

        Administrator GetById(int id);

        IEnumerable<Administrator> GetAll();

        Administrator Delete(Administrator administrator);
    }
}