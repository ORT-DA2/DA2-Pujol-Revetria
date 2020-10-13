using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrations.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Controllers;
using WebApi.DTOs;

namespace WebApi.Tests
{
    [TestClass]
    public class BookingStageControllerTest
    {
        [TestMethod]
        public void TestGetBookingStatus()
        {
            BookingStage bookingStage = new BookingStage();
            bookingStage.Description = "a";
            bookingStage.Status = Status.Accepted;
            BookingStageModelOut bookingStageModel = new BookingStageModelOut(bookingStage);
            List<BookingStageModelOut> list = new List<BookingStageModelOut>();
            list.Add(bookingStageModel);
            var mock = new Mock<IBookingStageLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetCurrentStatusByBooking(It.IsAny<int>())).Returns(bookingStage);
            var controller = new BookingStageController(mock.Object);
            var result = controller.GetBookingStatus(1) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
        
        [TestMethod]
        public void CreateStage()
        {
            BookingStage bookingStage = new BookingStage();
            bookingStage.Description = "a";
            bookingStage.Status = Status.Accepted;
            bookingStage.AsociatedBookingId = 1;
            bookingStage.AdministratorId = 1;
            BookingStageModelIn bookingStageModel = new BookingStageModelIn();
            bookingStageModel.Description = bookingStage.Description;
            bookingStageModel.Status = bookingStage.Status.ToString();
            bookingStageModel.BookingId = bookingStage.AsociatedBookingId;
            bookingStageModel.AdminId = bookingStage.AdministratorId;
            var mock = new Mock<IBookingStageLogic>(MockBehavior.Strict);
            mock.Setup(p => p.AddBookingStage(It.IsAny<BookingStage>())).Returns(bookingStage);
            var controller = new BookingStageController(mock.Object);
            var result = controller.NewStage(bookingStageModel) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
