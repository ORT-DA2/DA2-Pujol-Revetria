using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class BookingStageTest
    {
        private BookingStage bookingStage;

        [TestInitialize]
        public void StartUp()
        {
            bookingStage = new BookingStage();
        }

        [TestCleanup]
        public void CleanUp()
        {
            bookingStage = new BookingStage();
        }

        [TestMethod]
        public void TestDescriptionSet()
        {
            bookingStage.Description = "test test@ test123";
            Assert.AreEqual(bookingStage.Description, "test test@ test123");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetNull()
        {
            bookingStage.Description = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetSpaces()
        {
            bookingStage.Description = "    ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetEmpty()
        {
            bookingStage.Description = "";
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.bookingStage.Id = 1;
            BookingStage test = new BookingStage
            {
                Id = 1
            };
            Assert.IsTrue(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.bookingStage.Id = 1;
            BookingStage test = new BookingStage
            {
                Id = 2
            };
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.bookingStage.Id = 1;
            BookingStage test = new BookingStage
            {
                Id = 2
            };
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.bookingStage.Id = 1;
            BookingStage test = null;
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.bookingStage.Id = 1;
            Assert.IsFalse(bookingStage.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.bookingStage.Id = 1;
            Booking test = new Booking();
            Assert.IsFalse(bookingStage.Equals(test));
        }
    }
}