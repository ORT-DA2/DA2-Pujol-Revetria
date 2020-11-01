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
    public class ReportControllerTest
    {
        [TestMethod]
        public void TestGetReport()
        {
            string touristicSpotName = "a";
            DateTime start = new DateTime(2020, 01, 20);
            DateTime end = new DateTime(2020, 02, 20);
            var mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            ReportTupleReturn reportTuple = new ReportTupleReturn { AccommodationName="1", Count = 1};
            List<ReportTupleReturn> list = new List<ReportTupleReturn>();
            list.Add(reportTuple);
            mock.Setup(p => p.GetReport(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(list);
            var controller = new ReportController(mock.Object);
            var result = controller.GetReport(touristicSpotName,start,end) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
