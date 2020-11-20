using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class GuestTest
    {
        private Guest guest;

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
            guest.Amount = 1;

            Assert.AreEqual(guest.Amount, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeAmountException))]
        public void TestAmountSetNegative()
        {
            guest.Amount = -1;
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.guest.Id = 1;
            Guest test = new Guest
            {
                Id = 1
            };

            Assert.IsTrue(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.guest.Id = 1;
            Guest test = new Guest
            {
                Id = 2
            };

            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.guest.Id = 1;
            Guest test = new Guest
            {
                Id = 2
            };

            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.guest.Id = 1;
            Guest test = null;

            Assert.IsFalse(guest.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.guest.Id = 1;

            Assert.IsFalse(guest.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.guest.Id = 1;
            Booking test = new Booking();

            Assert.IsFalse(guest.Equals(test));
        }
    }
}