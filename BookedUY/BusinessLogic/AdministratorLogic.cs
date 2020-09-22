using BusinessLogicInterface;
using DataAccessInterface;
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
    }
}
