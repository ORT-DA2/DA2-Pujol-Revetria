using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests
{
    [TestClass]
    public class GuestTest
    {
        Guest guest;
        [TestInitialize]
        public void StartUp()
        {
            guest = new Guest();
        }

        [TestCleanup]
        public void CleanUp()
        {
            guest = new Guest();
        }

        [TestMethod]
        public void TestAmountSet()
        {
            int test = 1;
            guest.Amount = test;
            Assert.AreEqual(guest.Amount, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeAmountException))]
        public void TestAmountSetNegative()
        {
            int test = -1;
            guest.Amount = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            this.guest.Id = testId;
            Guest test = new Guest();
            test.Id = testId;
            Assert.IsTrue(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.guest.Id = testId1;
            Guest test = new Guest();
            test.Id = testId2;
            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.guest.Id = testId1;
            Guest test = new Guest();
            test.Id = testId2;
            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            this.guest.Id = testId1;
            Guest test = null;
            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            this.guest.Id = testId1;
            string test = "testing";
            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            this.guest.Id = testId1;
            Booking test = new Booking();
            Assert.IsFalse(guest.Equals(test));
        }
    }
}
