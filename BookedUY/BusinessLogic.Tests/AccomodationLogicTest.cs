using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class AccommodationLogicTest
    {
        [TestMethod]
        public void GetReviewsByAccommodationTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 1,
                Name = "abz",
                SpotId = 1
            };            
            List<Accommodation> accommodations = new List<Accommodation>();
            Review review1 = new Review()
            {
                Id = 2,
                Comment = "Prueba123",
                Score = 1
            };
            Review review2 = new Review()
            {
                Id = 3,
                Comment = "Prueba123",
                Score = 1
            };
            List<Review> reviews = new List<Review>
            {
                review1,
                review2
            };
            accommodations.Add(accommodation);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockReview.Setup(p => p.GetByAccommodation(It.IsAny<int>())).Returns(reviews);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.GetReviewsByAccommodation(1);

            mockAccommodation.VerifyAll();
            Assert.IsTrue(reviews.SequenceEqual(result.Item2));
        }

        [TestMethod]
        public void AddReviewTest()
        {
            Accommodation accom = new Accommodation()
            {
                Id = 1,
                Name = "a"
            };
            Booking booking = new Booking()
            {
                Id = 1,
                AccommodationId = 1,
                HeadGuest = new Tourist()
                {
                    Id = 1,
                    Email = "a@a.com",
                    Name = "a",
                    LastName = "a"
                }
            };
            Review review = new Review()
            {
                Id = 5,
                BookingId = 1,
                Comment = "test",
                Score = 1,
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockReview.Setup(p => p.Add(It.IsAny<Review>())).Returns(review);
            mockBooking.Setup(a => a.GetById(It.IsAny<int>())).Returns(booking);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddReview(review);

            mockAccommodation.VerifyAll();
            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(review));
        }

        [TestMethod]
        public void AddAccommodationTest()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);

            mockAccommodation.VerifyAll();
            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [TestMethod]
        public void AddAccommodationTest2()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);

            mockAccommodation.VerifyAll();
            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddAccommodationNotFoundTest()
        { 
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns<TouristicSpot>(null);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddAccommodationNotFoundTest2()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns<TouristicSpot>(null);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);
        }

        [ExpectedException(typeof(AlreadyExistsException))]
        [TestMethod]
        public void AddAccommodationAlreadyExistsTest()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddAccommodationNullInputTest()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = 5

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = images,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 0,
            };
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddAccommodationNullInputTest2()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abom",
                Address = "ag",
                Images = null,
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5,
                SpotId = 3,
            };

            TouristicSpot spot = new TouristicSpot()
            {
                Name = "a",
                Id = 6
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.AddAccommodation(accommodation);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz"
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.Delete(It.IsAny<Accommodation>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.DeleteAccommodation(accommodation);

            mockAccommodation.VerifyAll();
            Assert.AreEqual(result, accommodation);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteExceptionTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 3,
                Name = "ayi"
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.Delete(It.IsAny<Accommodation>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.DeleteAccommodation(accommodation);
        }

        [TestMethod]
        public void GetAvailableBySpotTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            List<Accommodation> accommodations = new List<Accommodation>();
            accommodations.Add(accommodation);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetAvailableBySpot(It.IsAny<int>())).Returns(accommodations);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.GetAvailableAccommodationBySpot(1);

            mockAccommodation.VerifyAll();
            Assert.IsTrue(accommodations.SequenceEqual(result));
        }

        [TestMethod]
        public void UpdateCapacityTrueTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.UpdateCapacity(2, true);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        public void UpdateCapacityFalseTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.UpdateCapacity(2, false);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void UpdateCapacityExceptionTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.UpdateCapacity(2, false);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        public void AddReviewTestOk()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            Booking booking = new Booking()
            {
                Id = 2
            };
            Review review = new Review()
            {
                Id = 1
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.GetById(It.IsAny<int>())).Returns(booking);
            mockReview.Setup(p => p.Add(It.IsAny<Review>())).Returns(review);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.AddReview(review);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        public void GetReviewsByAccommodation()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            Booking booking = new Booking()
            {
                Id = 2
            };
            Review review = new Review()
            {
                Id = 1
            };
            Review review2 = new Review()
            {
                Id = 2
            };
            List<Review> revs = new List<Review>()
            {
                review,
                review2
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockReview.Setup(p => p.GetByAccommodation(It.IsAny<int>())).Returns(revs);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            logic.GetReviewsByAccommodation(1);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        public void GetAllTest()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 2,
                Name = "abz",
                SpotId = 1
            };
            List<Accommodation> accommodations = new List<Accommodation>()
            { 
                accommodation 
            };
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetAll()).Returns(accommodations);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockReview = new Mock<IReviewRepository>(MockBehavior.Strict);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockReview.Object, mockBooking.Object);

            var result = logic.GetAll();

            mockAccommodation.VerifyAll();
            Assert.IsTrue(accommodations.SequenceEqual(result));
        }
    }
}