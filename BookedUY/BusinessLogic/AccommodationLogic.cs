using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristicSpotRepository spotRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IBookingRepository bookingRepository;

        public AccommodationLogic(IAccommodationRepository accommodationRepository, ITouristicSpotRepository spotRepository, IReviewRepository reviewRepository, IBookingRepository bookingRepository)
        {
            this.accommodationRepository = accommodationRepository;
            this.spotRepository = spotRepository;
            this.reviewRepository = reviewRepository;
            this.bookingRepository = bookingRepository;
        }

        public (double,IEnumerable<Review>) GetReviewsByAccommodation(int id)
        {
            var reviews = this.reviewRepository.GetByAccommodation(id);
            var avgScore = CalculateAverageScore(reviews);
            return (avgScore, reviews);
        }

        private double CalculateAverageScore(IEnumerable<Review> reviews)
        {
            int accum = 0;
            int count = 0;
            foreach (var item in reviews)
            {
                accum += item.Score;
                count++;
            }
            if (count == 0)
            {
                return 0;
            }
            return accum / count;
        }

        public Review AddReview(Review review)
        {
            var booking = this.bookingRepository.GetById(review.BookingId);
            if (booking == null)
            {
                throw new NotFoundException("Review Booking");
            }
            return this.reviewRepository.Add(review);
        }

        public Accommodation AddAccommodation(Accommodation accommodation)
        {
            CheckSpotId(accommodation);
            CheckAccommodationImages(accommodation);
            CheckAccommodationName(accommodation);
            CheckAccommodationId(accommodation);
            var newAccom = this.accommodationRepository.Add(accommodation);
            return newAccom;
        }
        private void CheckSpotId(Accommodation accommodation)
        {
            if (accommodation.SpotId == 0)
            {
                throw new NullInputException("Accommodation Spot");
            }
        }

        private void CheckAccommodationImages(Accommodation accommodation)
        {
            if (accommodation.Images == null)
            {
                throw new NullInputException("Accommodation Images");
            }
        }

        private void CheckAccommodationName(Accommodation accommodation)
        {
            if (this.accommodationRepository.GetByName(accommodation.Name) != null)
            {
                throw new AlreadyExistsException("Accommodation");
            }
        }

        private void CheckAccommodationId(Accommodation accommodation)
        {
            if (this.spotRepository.GetById(accommodation.SpotId) == null)
            {
                throw new NotFoundException("Accommodation Spot");
            }
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
        public IEnumerable<Accommodation> GetAll()
        {
            return this.accommodationRepository.GetAll();
        }
    }
}