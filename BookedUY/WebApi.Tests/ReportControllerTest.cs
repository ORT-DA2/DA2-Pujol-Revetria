using BusinessLogicInterface;
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
    public class ReportControllerTest
    {
        [TestMethod]
        public void TestGetReport()
        {
            string touristicSpotName = "a";
            DateTime start = new DateTime(2020, 01, 20);
            DateTime end = new DateTime(2020, 02, 20);
            var mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            (string, int) stringInt = ("a",1);
            List<(string, int)> list = new List<(string, int)>();
            list.Add(stringInt);
            mock.Setup(p => p.GetReport(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(list);
            var controller = new ReportController(mock.Object);
            var result = controller.GetReport(touristicSpotName,start,end) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
