using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests
{
    [TestClass]
    public class BookingTest
    {
        Booking booking;
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
            DateTime test = DateTime.Now.AddDays(1).Date;
            booking.CheckIn = test;
            Assert.AreEqual(booking.CheckIn, test);
        }

        [TestMethod]
        public void TestCheckIn2()
        {
            DateTime test = DateTime.Now.AddDays(300).Date;
            booking.CheckIn = test;
            Assert.AreEqual(booking.CheckIn, test);
        }

        [TestMethod]
        public void TestCheckIn3()
        {
            DateTime test = DateTime.Now.Date;
            booking.CheckIn = test;
            Assert.AreEqual(booking.CheckIn, test);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail()
        {
            DateTime test = DateTime.Now.AddDays(-1);
            booking.CheckIn = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail2()
        {
            DateTime test = DateTime.Now.AddDays(-200).Date;
            booking.CheckIn = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckInFail3()
        {
            DateTime test = DateTime.Now.AddHours(-28).Date;
            booking.CheckIn = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestCheckOut()
        {
            DateTime test = DateTime.Now.AddDays(1).Date;
            booking.CheckOut = test;
            Assert.AreEqual(booking.CheckOut,test);
        }

        [TestMethod]
        public void TestCheckOut2()
        {
            DateTime test = DateTime.Now.AddDays(300).Date;
            booking.CheckOut = test;
            Assert.AreEqual(booking.CheckOut, test);
        }

        [TestMethod]
        public void TestCheckOut3()
        {
            DateTime test = DateTime.Now.Date;
            booking.CheckOut = test;
            Assert.AreEqual(booking.CheckOut, test);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail()
        {
            DateTime test = DateTime.Now.AddDays(-1).Date;
            booking.CheckOut = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail2()
        {
            DateTime test = DateTime.Now.AddDays(-200).Date;
            booking.CheckOut = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutFail3()
        {
            DateTime test = DateTime.Now.AddHours(-28).Date;
            booking.CheckOut = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutBeforeCheckIn()
        {
            DateTime testIn = DateTime.Now.AddDays(5).Date;
            DateTime testOut = DateTime.Now.AddDays(2).Date;
            booking.CheckIn = testIn;
            booking.CheckOut = testOut;
            Assert.Fail();
        }


        [TestMethod]
        public void TestCheckOutAfterCheckIn()
        {
            DateTime testIn = DateTime.Now.AddDays(2).Date;
            DateTime testOut = DateTime.Now.AddDays(8).Date;
            booking.CheckIn = testIn;
            booking.CheckOut = testOut;
            Assert.IsTrue(booking.CheckIn<booking.CheckOut);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDateException))]
        public void TestCheckOutBeforeCheckIn2()
        {
            DateTime testIn = DateTime.Now.AddDays(10).Date;
            DateTime testOut = DateTime.Now.AddDays(9).Date;
            booking.CheckIn = testIn;
            booking.CheckOut = testOut;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            this.booking.Id = testId;
            Booking test = new Booking();
            test.Id = testId;
            Assert.IsTrue(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.booking.Id = testId1;
            Booking test = new Booking();
            test.Id = testId2;
            Assert.IsFalse(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            this.booking.Id = testId1;
            Booking test = null;
            Assert.IsFalse(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            this.booking.Id = testId1;
            string test = "testing";
            Assert.IsFalse(booking.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            this.booking.Id = testId1;
            Booking test = new Booking();
            Assert.IsFalse(booking.Equals(test));
        }
    }
}
