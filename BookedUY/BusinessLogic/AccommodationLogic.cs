﻿using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationRepository accommodationRepository;

        public AccommodationLogic(IAccommodationRepository accommodationRepository)
        {
            this.accommodationRepository = accommodationRepository;
        }

        public Accommodation AddAccommodation(Accommodation accommodation)
        {
            if (this.accommodationRepository.GetByName(accommodation.Name)==null)
            {
                var newAccom = this.accommodationRepository.Add(accommodation);
                return newAccom;
            }
            throw new AlreadyExistsException();
        }
    }
}
