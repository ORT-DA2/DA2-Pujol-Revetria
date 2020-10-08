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
            int testId = 5;
            List<Region> regions = new List<Region>();
            Region region = new Region();
            region.Id = testId;
            region.Name = "South";
            regions.Add(region);
            var mock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(regions);
            var logic = new RegionLogic(mock.Object);
            var result = logic.GetRegions();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(regions));
        }

        [TestMethod]
        public void GetRegionsNullTest()
        {

            List<Region> regions = new List<Region>();
            var mock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(regions);
            var logic = new RegionLogic(mock.Object);
            var result = logic.GetRegions();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(regions));
        }
    }
}
