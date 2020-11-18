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
    public class RegionLogicTest
    {
        [TestMethod]
        public void GetRegionsTest()
        {
            List<Region> regions = new List<Region>();
            Region region = new Region
            {
                Id = 5,
                Name = "South"
            };
            regions.Add(region);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetAll()).Returns(regions);
            var logic = new RegionLogic(mockRegion.Object);

            var result = logic.GetRegions();

            mockRegion.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(regions));
        }

        [TestMethod]
        public void GetRegionsNullTest()
        {
            List<Region> regions = new List<Region>();
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetAll()).Returns(regions);
            var logic = new RegionLogic(mockRegion.Object);

            var result = logic.GetRegions();

            mockRegion.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(regions));
        }
    }
}