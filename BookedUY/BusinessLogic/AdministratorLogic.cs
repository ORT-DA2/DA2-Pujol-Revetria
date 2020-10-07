using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {
        private readonly IAdministratorRepository administratorRepository;

        public AdministratorLogic(IAdministratorRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public Administrator AddAdministrator(Administrator administrator)
        {
            if (this.administratorRepository.GetByEmail(administrator.Email)==null)
            {
                var newAdmin = this.administratorRepository.Add(administrator);
                return newAdmin;
            }
            throw new AlreadyExistsException();
        }
    }
}
