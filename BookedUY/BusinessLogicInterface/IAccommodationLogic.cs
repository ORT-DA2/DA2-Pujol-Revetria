using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IAccommodationLogic
    {
        Accommodation AddAccommodation(Accommodation accommodation);
        void DeleteAccommodation(Accommodation accommodation);
        IEnumerable<Accommodation> GetAvailableAccommodationBySpot(int spotId);
        void UpdateCapacity(int accommodationId, bool capacity);
    }
}
