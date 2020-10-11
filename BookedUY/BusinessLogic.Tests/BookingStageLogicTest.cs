using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BookingStageLogicTest
    {
        [TestMethod]
        public void AddBookingStageTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 7;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns(booking);
            var logic = new BookingStageLogic(mock.Object,mock2.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void AddBookingStageExceptionTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 5;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns<Booking>(null);
            var logic = new BookingStageLogic(mock.Object, mock2.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        public void GetCurrentStatusByBookingTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 7;
            List<BookingStage> bookingStages = new List<BookingStage>();
            bookingStages.Add(bookingStage);
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByBooking(It.IsAny<int>())).Returns(bookingStages);
            var mock2 = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            var logic = new BookingStageLogic(mock.Object, mock2.Object);
            var result = logic.GetCurrentStatusByBooking(7);
            mock.VerifyAll();
            mock2.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }
    }
}
