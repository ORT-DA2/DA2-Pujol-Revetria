using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class RegionControllerTest
    {
        [TestMethod]
        public void TestGetAllBookingsOK()
        {
            Region region = new Region()
            {
                Name = "a"
            };
            List<Region> list = new List<Region>();
            list.Add(region);
            var mock = new Mock<IRegionLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetRegions()).Returns(list);
            var controller = new RegionController(mock.Object);
            var result = controller.Get() as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
