using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

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
                throw new AlreadyExistsException("Accommodation");
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