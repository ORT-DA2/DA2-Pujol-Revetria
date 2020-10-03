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
        private readonly IRepository<Administrator> administratorRepository;

        public AdministratorLogic(IRepository<Administrator> administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }
    }
}
