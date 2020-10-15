using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TouristicSpotLogicTest
    {
        [TestMethod]
        public void AddAccommodationTest()
        {
            int testId = 5;
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = testId,
                Name = "abm",
                RegionId = 3,
                Categories = categories
            };
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
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = testId,
                Name = "abm",
                RegionId = 3,
                Categories = categories
            };
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.AddTouristicSpot(touristicSpot);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddAccommodationNullInputTest()
        {
            int testId = 5;
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = testId,
                Name = "abm",
                RegionId = 0,
                Categories = categories
            };
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var logic = new TouristicSpotLogic(mock.Object);
            var result = logic.AddTouristicSpot(touristicSpot);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddAccommodationNullInput2Test()
        {
            int testId = 5;
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = testId,
                Name = "abm",
                RegionId = 5,
                Categories = null
            };
            var mock = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mock.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
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