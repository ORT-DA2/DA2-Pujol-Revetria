using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IRepository<Accommodation> accommodationRepository;

        public AccommodationLogic(IRepository<Accommodation> accommodationRepository)
        {
            this.accommodationRepository = accommodationRepository;
        }
    }
}
