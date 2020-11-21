using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebApi.Controllers;
using WebApi.DTOs;

namespace WebApi.Tests
{
    [TestClass]
    public class AccommodationControllerTest
    {
        [TestMethod]
        public void TestGetAccommodationsInSpotOK()
        {
            Accommodation accommodation = new Accommodation
            {
                Id = 5,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0
            };
            List<Accommodation> listAccommodations = new List<Accommodation>
            {
                accommodation
            };
            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetAvailableAccommodationBySpot(It.IsAny<int>())).Returns(listAccommodations);
            var controller = new AccommodationController(mockAccommodation.Object);

            var result = controller.GetAccommodationsInSpot(1) as OkObjectResult;

            mockAccommodation.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetAccommodationsByIdOK()
        {
            List<AccommodationImage> listAccommodations = new List<AccommodationImage>
            {
                new AccommodationImage() { Image = "h" }
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Images = listAccommodations
            };

            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetReviewsByAccommodation(It.IsAny<int>())).Returns((0,new List<Review>()));
            var controller = new AccommodationController(mockAccommodation.Object);

            var result = controller.Get(5) as OkObjectResult;

            mockAccommodation.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateAccommodationOK()
        {
            Accommodation accommodation = new Accommodation()
            {
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Id = 1,
                Images = new List<AccommodationImage>(),
                Full = false
            };
            string[] image = new string[1];
            image[0] = "h";
            AccommodationModelIn accommodationModel = new AccommodationModelIn()
            {
                Address = accommodation.Address,
                Contact = accommodation.ContactNumber,
                Name = accommodation.Name,
                Information = accommodation.Information,
                Price = accommodation.PricePerNight,
                SpotId = accommodation.SpotId,
                Images = image
            };
            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.AddAccommodation(It.IsAny<Accommodation>())).Returns(accommodation);
            var controller = new AccommodationController(mockAccommodation.Object);

            var result = controller.CreateAccommodation(accommodationModel) as OkObjectResult;

            mockAccommodation.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestUpdateCapaityOK()
        {
            Accommodation accommodation = new Accommodation
            {
                Id = 5,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Full = true
            };
            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var controller = new AccommodationController(mockAccommodation.Object);

            controller.UpdateCapacity(5, false);

            mockAccommodation.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            Accommodation accommodation = new Accommodation
            {
                Id = 5,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Full = true
            };
            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.DeleteAccommodation(It.IsAny<Accommodation>())).Returns(accommodation);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var controller = new AccommodationController(mockAccommodation.Object);

            var result = controller.Delete(5) as OkObjectResult;

            mockAccommodation.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = 5,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Full = true
            };
            List<Accommodation> accommodations = new List<Accommodation>()
            {
                accommodation
            };
            var mockAccommodation = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetAll()).Returns(accommodations);
            var controller = new AccommodationController(mockAccommodation.Object);

            var result = controller.Get() as OkObjectResult;

            mockAccommodation.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}