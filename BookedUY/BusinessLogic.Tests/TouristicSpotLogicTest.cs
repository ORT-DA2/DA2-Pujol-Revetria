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
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 5,
                Name = "abm",
                RegionId = 3,
                Categories = categories
            };
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.AddTouristicSpot(touristicSpot);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void AddTouristicSpotAlreadyExistsTest()
        {
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 5,
                Name = "abm",
                RegionId = 3,
                Categories = categories
            };
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.AddTouristicSpot(touristicSpot);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpot));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddAccommodationNullInputTest()
        {
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 5,
                Name = "abm",
                RegionId = 0,
                Categories = categories
            };
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.AddTouristicSpot(touristicSpot);
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddAccommodationNullInput2Test()
        {
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 5,
                Name = "abm",
                RegionId = 5,
                Categories = null
            };
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.AddTouristicSpot(touristicSpot);
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetAllTest()
        {
            TouristicSpot touristicSpot = new TouristicSpot
            {
                Id = 5,
                Name = "abom"
            };
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetAll()).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.GetSpotsByRegionAndCategory(categories, -1);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetByRegionTest()
        {
            TouristicSpot touristicSpot = new TouristicSpot
            {
                Id = 5,
                Name = "abom"
            };
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetByRegion(It.IsAny<int>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.GetSpotsByRegionAndCategory(categories, 0);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionGetByCategoryTest()
        {
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = 5;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            categories.Add(1);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetByCategory(It.IsAny<List<int>>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.GetSpotsByRegionAndCategory(categories, -1);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }

        [TestMethod]
        public void GetSpotsByCategoryAndRegionTest()
        {
            TouristicSpot touristicSpot = new TouristicSpot();
            touristicSpot.Id = 5;
            touristicSpot.Name = "abom";
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>();
            List<int> categories = new List<int>();
            categories.Add(1);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetByCategoryAndRegion(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(touristicSpots);
            var logic = new TouristicSpotLogic(mockTouristicSpot.Object);

            var result = logic.GetSpotsByRegionAndCategory(categories, 0);

            mockTouristicSpot.VerifyAll();
            Assert.IsTrue(result.Equals(touristicSpots));
        }
    }
}