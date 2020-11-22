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
    public class TouristicSpotControllerTest
    {
        [TestMethod]
        public void TestGetTouristicSpot()
        {
            List<TouristicSpot> list = new List<TouristicSpot>
            {
                new TouristicSpot()
                {
                Name = "a",
                Description = "b"
                }
            };
            var mockTouristicSpot = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetSpotsByRegionAndCategory(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(list);
            var controller = new TouristicSpotController(mockTouristicSpot.Object);

            var result = controller.GetByRegionCategory(-1, null) as OkObjectResult;

            mockTouristicSpot.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetByRegionAndCategory()
        {
            TouristicSpot touristicSpot = new TouristicSpot
            {
                Name = "a",
                Description = "b"
            };
            List<int> listCategories = new List<int>
            {
                1
            };
            List<TouristicSpot> list = new List<TouristicSpot>
            {
                touristicSpot
            };
            var mockTouristicSpot = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetSpotsByRegionAndCategory(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(list);
            var controller = new TouristicSpotController(mockTouristicSpot.Object);

            var result = controller.GetByRegionCategory(1, listCategories) as OkObjectResult;

            mockTouristicSpot.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateTouristicSpot()
        {
            TouristicSpot touristicSpot = new TouristicSpot
            {
                Name = "a",
                Description = "b"
            };
            TouristicSpotModelIn touristicSpotModel = new TouristicSpotModelIn
            {
                Description = touristicSpot.Description,
                Name = touristicSpot.Name
            };
            int[] list = new int[1];
            list[0] = 1;
            touristicSpotModel.Categories = list;
            var mockTouristicSpot = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.AddTouristicSpot(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            var controller = new TouristicSpotController(mockTouristicSpot.Object);

            var result = controller.CreateSpot(touristicSpotModel) as OkObjectResult;

            mockTouristicSpot.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}