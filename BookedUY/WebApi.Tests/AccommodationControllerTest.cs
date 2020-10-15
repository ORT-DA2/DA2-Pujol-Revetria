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
            int testId = 5;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abm";
            accommodation.SpotId = 1;
            accommodation.Address = "a";
            accommodation.ContactNumber = "a";
            accommodation.Information = "a";
            accommodation.PricePerNight = 5.0;
            List<Accommodation> list = new List<Accommodation>();
            list.Add(accommodation);
            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetAvailableAccommodationBySpot(It.IsAny<int>())).Returns(list);
            var controller = new AccommodationController(mock.Object);
            var result = controller.GetAccommodationsInSpot(1) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetAccommodationsByIdOK()
        {
            int testId = 5;
            List<AccommodationImage> list = new List<AccommodationImage>();
            list.Add(new AccommodationImage() { Image = "h" });
            Accommodation accommodation = new Accommodation()
            {
                Id = testId,
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Images = list
            };
            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var controller = new AccommodationController(mock.Object);
            var result = controller.Get(5) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateAccommodationOK()
        {
            int testId = 5;
            Accommodation accommodation = new Accommodation()
            {
                Name = "abm",
                SpotId = 1,
                Address = "a",
                ContactNumber = "a",
                Information = "a",
                PricePerNight = 5.0,
                Id = 1,
                Images = new List<AccommodationImage>()
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
            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(p => p.AddAccommodation(It.IsAny<Accommodation>())).Returns(accommodation);
            var controller = new AccommodationController(mock.Object);
            var result = controller.CreateAccommodation(accommodationModel) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestUpdateCapaityOK()
        {
            int testId = 5;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abm";
            accommodation.SpotId = 1;
            accommodation.Address = "a";
            accommodation.ContactNumber = "a";
            accommodation.Information = "a";
            accommodation.PricePerNight = 5.0;
            accommodation.Full = true;
            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(p => p.UpdateCapacity(It.IsAny<int>(), It.IsAny<bool>()));
            var controller = new AccommodationController(mock.Object);
            controller.UpdateCapacity(5, false);
            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int testId = 5;
            Accommodation accommodation = new Accommodation();
            accommodation.Id = testId;
            accommodation.Name = "abm";
            accommodation.SpotId = 1;
            accommodation.Address = "a";
            accommodation.ContactNumber = "a";
            accommodation.Information = "a";
            accommodation.PricePerNight = 5.0;
            accommodation.Full = true;
            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(p => p.DeleteAccommodation(It.IsAny<Accommodation>())).Returns(accommodation);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var controller = new AccommodationController(mock.Object);
            var result = controller.Delete(5) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}