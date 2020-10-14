using Domain;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IAccommodationRepository : IRepository<Accommodation>
    {
        Accommodation GetByName(string name);

        IEnumerable<Accommodation> GetAvailableBySpot(int spotId);

        void UpdateCapacity(int accommodationId, bool capacity);
    }
}