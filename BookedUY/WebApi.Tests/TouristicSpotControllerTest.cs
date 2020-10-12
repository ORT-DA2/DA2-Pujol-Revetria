using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrations.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
            var result = controller.Get() as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
        public void TestGetByRegionAndCategory()
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

        public void TestCreateTouristicSpot()
        {
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Name = "a";
            touristicSpot.Description = "b";
            TouristicSpotModelIn touristicSpotModel = new TouristicSpotModelIn();
            touristicSpotModel.Description = touristicSpot.Description;
            touristicSpotModel.Name = touristicSpot.Name;
            var mock = new Mock<ITouristicSpotLogic>(MockBehavior.Strict);
            mock.Setup(p => p.AddTouristicSpot(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            var controller = new TouristicSpotController(mock.Object);
            var result = controller.CreateSpot(touristicSpotModel) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
