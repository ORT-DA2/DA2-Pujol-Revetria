using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainTests
{
    [TestClass]
    public class BookingTest
    {
        private Booking booking;

        [TestInitialize]
        public void StartUp()
        {
            booking = new Booking();
        }

        [TestCleanup]
        public void CleanUp()
        {
            booking = new Booking();
        }

        [TestMethod]
        public void TestCheckIn()
        {
            booking.CheckIn = DateTime.Now.AddDays(1).Date;

            Assert.AreEqual(booking.CheckIn, DateTime.Now.AddDays(1).Date);
        }

        [TestMethod]
        public void TestCheckIn2()
        {
            booking.CheckIn = DateTime.Now.AddDays(300).Date;

            Assert.AreEqual(booking.CheckIn, DateTime.Now.AddDays(300).Date);
        }

        [TestMethod]
        public void TestCheckIn3()
        {
            booking.CheckIn = DateTime.Now.Date;

            Assert.AreEqual(booking.CheckIn, DateTime.Now.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail()
        {
            booking.CheckIn = DateTime.Now.AddDays(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail2()
        {
            booking.CheckIn = DateTime.Now.AddDays(-200).Date;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail3()
        {
            booking.CheckIn = DateTime.Now.AddHours(-28).Date;
        }

        [TestMethod]
        public void TestCheckOut()
        {
            booking.CheckOut = DateTime.Now.AddDays(1).Date;

            Assert.AreEqual(booking.CheckOut, DateTime.Now.AddDays(1).Date);
        }

        [TestMethod]
        public void TestCheckOut2()
        {
            booking.CheckOut = DateTime.Now.AddDays(300).Date;

            Assert.AreEqual(booking.CheckOut, DateTime.Now.AddDays(300).Date);
        }

        [TestMethod]
        public void TestCheckOut3()
        {
            booking.CheckOut = DateTime.Now.Date;

            Assert.AreEqual(booking.CheckOut, DateTime.Now.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail()
        {
            booking.CheckOut = DateTime.Now.AddDays(-1).Date;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail2()
        {
            booking.CheckOut = DateTime.Now.AddDays(-200).Date;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail3()
        {
            booking.CheckOut = DateTime.Now.AddHours(-28).Date;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutBeforeCheckIn()
        {
            booking.CheckIn = DateTime.Now.AddDays(5).Date;
            booking.CheckOut = DateTime.Now.AddDays(2).Date;
        }

        [TestMethod]
        public void TestCheckOutAfterCheckIn()
        {
            booking.CheckIn = DateTime.Now.AddDays(2).Date;
            booking.CheckOut = DateTime.Now.AddDays(8).Date;

            Assert.IsTrue(booking.CheckIn < booking.CheckOut);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutBeforeCheckIn2()
        {
            booking.CheckIn = DateTime.Now.AddDays(10).Date;
            booking.CheckOut = DateTime.Now.AddDays(9).Date;
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.booking.Id = 1;
            Booking test = new Booking
            {
                Id = 1
            };

            Assert.IsTrue(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.booking.Id = 1;
            Booking test = new Booking
            {
                Id = 2
            };

            Assert.IsFalse(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.booking.Id = 1;
            Booking test = null;

            Assert.IsFalse(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.booking.Id = 1;

            Assert.IsFalse(booking.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.booking.Id = 1;
            Booking test = new Booking();

            Assert.IsFalse(booking.Equals(test));
        }
    }
}