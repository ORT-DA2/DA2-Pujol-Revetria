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
        private readonly IAccommodationRepository administratorRepository;

        public AdministratorLogic(IAccommodationRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }
    }
}
