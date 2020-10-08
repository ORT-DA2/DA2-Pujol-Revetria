using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BookingLogicTest
    {
        [TestMethod]
        public void GetAllBookingsTest()
        {
            List<Booking> bookings = new List<Booking>();
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(bookings);
            var logic = new BookingLogic(mock.Object);
            var result = logic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(bookings));
        }

        [TestMethod]
        public void GetAddBookingsTest()
        {
            int testId = 9;
            List<Guest> guests = new List<Guest>();
            Booking booking = new Booking();
            booking.Id = testId;
            booking.Guests = guests;
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var logic = new BookingLogic(mock.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }
    }
}
