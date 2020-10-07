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

        public void DeleteAccommodation(Accommodation accommodation)
        {
            if (this.accommodationRepository.GetByName(accommodation.Name) != null)
            {
                this.accommodationRepository.Delete(accommodation);
            }
            throw new AccommodationNotFoundException();
        }

        public IEnumerable<Accommodation> GetAvailableAccommodationBySpot(int spotId)
        {
            return this.accommodationRepository.GetAvailableBySpot(spotId);
        }

        public void UpdateCapacity(int accommodationId,bool capacity)
        {
            if (this.accommodationRepository.GetById(accommodationId) != null)
            {
                this.accommodationRepository.UpdateCapacity(accommodationId, capacity);
            }
            throw new AccommodationNotFoundException();
        }
    }
}
