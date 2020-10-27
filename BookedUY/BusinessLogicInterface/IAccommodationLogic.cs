using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IAccommodationLogic
    {
        Accommodation AddAccommodation(Accommodation accommodation);

        Accommodation DeleteAccommodation(Accommodation accommodation);

        IEnumerable<Accommodation> GetAvailableAccommodationBySpot(int spotId);

        void UpdateCapacity(int accommodationId, bool capacity);

        Accommodation GetById(int id);

        (double, IEnumerable<Review>) GetReviewsByAccommodation(int id);

        Review AddReview(Review review);

    }
}