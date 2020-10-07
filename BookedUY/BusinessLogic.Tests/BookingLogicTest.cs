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
    }
}
