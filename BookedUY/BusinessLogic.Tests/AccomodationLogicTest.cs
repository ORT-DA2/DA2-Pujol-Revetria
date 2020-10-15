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
        public void AddAccommodationTest()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [TestMethod]
        public void AddAccommodationTest2()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            var expected = logic.GetById(5);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(expected));
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddAccommodationNotFoundTest()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            var expected = logic.GetById(5);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(expected));
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddAccommodationNotFoundTest2()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns<TouristicSpot>(null);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            var expected = logic.GetById(5);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(expected));
        }

        [ExpectedException(typeof(AlreadyExistsException))]
        [TestMethod]
        public void AddAccommodationAlreadyExistsTest()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId
                
            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddAccommodationNullInputTest()
        {
            int testId = 5;
            List<AccommodationImage> images = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                Image = "image",
                AccommodationId = testId

            };
            images.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddAccommodationNullInputTest2()
        {
            int testId = 5;
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
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
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(spot);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.AddAccommodation(accommodation);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(accommodation));
        }

        [TestMethod]
        public void DeleteTest()
        {
            int testId = 2;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abz";
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            mock.Setup(p => p.Delete(It.IsAny<Accommodation>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.DeleteAccommodation(accommodation);
            mock.VerifyAll();
            Assert.AreEqual(result, accommodation);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteExceptionTest()
        {
            int testId = 3;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "ayi";
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mock.Setup(p => p.Delete(It.IsAny<Accommodation>())).Returns(accommodation);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            logic.DeleteAccommodation(accommodation);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAvailableBySpotTest()
        {
            int testId = 2;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abz";
            accommodation.SpotId = 1;
            List<Accommodation> accommodations = new List<Accommodation>();
            accommodations.Add(accommodation);
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetAvailableBySpot(It.IsAny<int>())).Returns(accommodations);
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            var result = logic.GetAvailableAccommodationBySpot(1);
            mock.VerifyAll();
            Assert.IsTrue(accommodations.SequenceEqual(result));
        }

        [TestMethod]
        public void UpdateCapacityTrueTest()
        {
            int testId = 2;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abz";
            accommodation.SpotId = 1;
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            mock.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            logic.UpdateCapacity(2, true);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateCapacityFalseTest()
        {
            int testId = 2;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abz";
            accommodation.SpotId = 1;
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            mock.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            logic.UpdateCapacity(2, false);
            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void UpdateCapacityExceptionTest()
        {
            int testId = 2;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abz";
            accommodation.SpotId = 1;
            var mock = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            mock.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var mock2 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new AccommodationLogic(mock.Object, mock2.Object);
            logic.UpdateCapacity(2, false);
            mock.VerifyAll();
        }
    }
}