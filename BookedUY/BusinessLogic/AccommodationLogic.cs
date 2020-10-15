﻿using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristicSpotRepository spotRepository;


        public AccommodationLogic(IAccommodationRepository accommodationRepository, ITouristicSpotRepository spotRepository)
        {
            this.accommodationRepository = accommodationRepository;
            this.spotRepository = spotRepository;
        }

        public Accommodation AddAccommodation(Accommodation accommodation)
        {
            if (accommodation.SpotId == 0)
            {
                throw new NullInputException("Accommodation Spot");
            }
            if (accommodation.Images == null)
            {
                throw new NullInputException("Accommodation Images");
            }
            if (this.accommodationRepository.GetByName(accommodation.Name) != null)
            {
                throw new AlreadyExistsException("Accommodation");
            }
            if (this.spotRepository.GetById(accommodation.SpotId)==null)
            {
                throw new NotFoundException("Accommodation Spot");
            }
            var newAccom = this.accommodationRepository.Add(accommodation);
            return newAccom;
        }

        public Accommodation DeleteAccommodation(Accommodation accommodation)
        {
            if (this.accommodationRepository.GetByName(accommodation.Name) == null)
            {
                throw new NotFoundException("Accommodation");
            }
            return this.accommodationRepository.Delete(accommodation);
        }

        public IEnumerable<Accommodation> GetAvailableAccommodationBySpot(int spotId)
        {
            return this.accommodationRepository.GetAvailableBySpot(spotId);
        }

        public void UpdateCapacity(int accommodationId, bool capacity)
        {
            if (this.accommodationRepository.GetById(accommodationId) == null)
            {
                throw new NotFoundException("Accommodation");
            }
            this.accommodationRepository.UpdateCapacity(accommodationId, capacity);
        }

        public Accommodation GetById(int id)
        {
            if (this.accommodationRepository.GetById(id) == null)
            {
                throw new NotFoundException("Accommodation");
            }
            return this.accommodationRepository.GetById(id);
        }
    }
}