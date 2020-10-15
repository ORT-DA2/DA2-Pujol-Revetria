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
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Name = "a";
            touristicSpot.Description = "b";
            List<TouristicSpot> list = new List<TouristicSpot>();
            list.Add(touristicSpot);
            var mock = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetSpotsByRegionAndCategory(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(list);
            var controller = new TouristicSpotController(mock.Object);
            var result = controller.GetByRegionCategory(-1, null) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetByRegionAndCategory()
        {
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Name = "a";
            touristicSpot.Description = "b";
            List<int> listCat = new List<int>();
            listCat.Add(1);
            List<TouristicSpot> list = new List<TouristicSpot>();
            list.Add(touristicSpot);
            var mock = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetSpotsByRegionAndCategory(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(list);
            var controller = new TouristicSpotController(mock.Object);
            var result = controller.GetByRegionCategory(1, listCat) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateTouristicSpot()
        {
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Name = "a";
            touristicSpot.Description = "b";
            TouristicSpotModelIn touristicSpotModel = new TouristicSpotModelIn();
            touristicSpotModel.Description = touristicSpot.Description;
            touristicSpotModel.Name = touristicSpot.Name;
            int[] list = new int[1];
            list[0] = 1;
            touristicSpotModel.Categories = list;
            var mock = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mock.Setup(p => p.AddTouristicSpot(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            var controller = new TouristicSpotController(mock.Object);
            var result = controller.CreateSpot(touristicSpotModel) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}