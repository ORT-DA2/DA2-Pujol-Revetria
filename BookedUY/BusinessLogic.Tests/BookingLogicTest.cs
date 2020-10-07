using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using BusinessLogic;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BookingLogicTest
    {
        [TestMethod] 
        public void TestMethod2() 
        {
            List<Booking> bookings = new List<Booking>();
            var mock = new Mock<IRepository<Booking>>(MockBehavior.Strict); 
            mock.Setup(p => p.GetAll()).Returns(bookings);
            var logic = new BookingLogic();
            Assert.AreEqual("Jignesh", result);
        }
    }
}
