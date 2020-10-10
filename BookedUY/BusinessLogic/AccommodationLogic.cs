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
            if (this.accommodationRepository.GetByName(accommodation.Name) != null)
            {
                throw new AlreadyExistsException();
            }
            var newAccom = this.accommodationRepository.Add(accommodation);
            return newAccom;
        }

        public void DeleteAccommodation(Accommodation accommodation)
        {
            if (this.accommodationRepository.GetByName(accommodation.Name) == null)
            {
                throw new AccommodationNotFoundException();
            }
            this.accommodationRepository.Delete(accommodation);
        }

        public IEnumerable<Accommodation> GetAvailableAccommodationBySpot(int spotId)
        {
            return this.accommodationRepository.GetAvailableBySpot(spotId);
        }

        public void UpdateCapacity(int accommodationId, bool capacity)
        {
            if (this.accommodationRepository.GetById(accommodationId) == null)
            {
                throw new AccommodationNotFoundException();
            }
            this.accommodationRepository.UpdateCapacity(accommodationId, capacity);
        }
        public Accommodation GetById(int id)
        {
            if (this.accommodationRepository.GetById(id) == null)
            {
                throw new AccommodationNotFoundException();
            }
            return this.accommodationRepository.GetById(id);
        }
    }
}
