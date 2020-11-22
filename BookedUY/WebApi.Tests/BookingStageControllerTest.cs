using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            BookingStage bookingStage = new BookingStage
            {
                Description = "a",
                Status = Status.Accepted
            };
            BookingStageModelOut bookingStageModel = new BookingStageModelOut(bookingStage);
            List<BookingStageModelOut> listBookingStageModelOut = new List<BookingStageModelOut>
            {
                bookingStageModel
            };
            var mockBookingStage = new Mock<IBookingStageLogic>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.GetCurrentStatusByBooking(It.IsAny<int>())).Returns(bookingStage);
            var controller = new BookingStageController(mockBookingStage.Object);

            var result = controller.GetBookingStatus(1) as OkObjectResult;

            mockBookingStage.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void CreateStage()
        {
            BookingStage bookingStage = new BookingStage
            {
                Description = "a",
                Status = Status.Accepted,
                AsociatedBookingId = 1,
                AdministratorId = 1
            };
            BookingStageModelIn bookingStageModel = new BookingStageModelIn
            {
                Description = bookingStage.Description,
                Status = bookingStage.Status.ToString(),
                BookingId = bookingStage.AsociatedBookingId,
                AdminId = bookingStage.AdministratorId
            };
            var mockBookingStage = new Mock<IBookingStageLogic>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.AddBookingStage(It.IsAny<BookingStage>())).Returns(bookingStage);
            var controller = new BookingStageController(mockBookingStage.Object);

            var result = controller.NewStage(bookingStageModel) as OkObjectResult;

            mockBookingStage.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}