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
    public class TouristicSpotLogicTest
    {
        [TestMethod]
        public void AddAccommodationTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abm";
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.AddTouristicSpot(touristicSpot);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void AddTouristicSpotAlreadyExistsTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abom";
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.AddTouristicSpot(touristicSpot);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetAllTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.GetSpotsByRegionAndCategory(categories, -1);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetByRegionTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByRegion(It.IsAny<int>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.GetSpotsByRegionAndCategory(categories, 0);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetByCategoryTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            categories.Add(1);
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByCategory(It.IsAny<List<int>>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.GetSpotsByRegionAndCategory(categories, -1);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionTest()
        {
            int testId = 5;
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = testId;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            categories.Add(1);
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByCategoryAndRegion(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.GetSpotsByRegionAndCategory(categories, 0);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }
    }
}
