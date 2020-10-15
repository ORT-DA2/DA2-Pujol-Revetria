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
        public void AddBookingsTest()
        {
            int testId = 9;
            List<Guest> guests = new List<Guest>();
            Guest guest = new Guest()
            {
                Amount = 2,
                Multiplier = 0.5
            };
            guests.Add(guest);
            Booking booking = new Booking()
            {
                Id = testId,
                Guests = guests,
                AccommodationId = 3
            };
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var logic = new BookingLogic(mock.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest()
        {
            int testId = 9;
            Booking booking = new Booking()
            {
                Id = testId,
                Guests = null,
                AccommodationId = 3
            };
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var logic = new BookingLogic(mock.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest2()
        {
            int testId = 9;
            Booking booking = new Booking()
            {
                Id = testId,
                Guests = null,
                AccommodationId = 0
            };
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var logic = new BookingLogic(mock.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }
    }
}