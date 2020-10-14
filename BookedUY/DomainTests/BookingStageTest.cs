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
            string test = "test test@ test123";
            bookingStage.Description = test;
            Assert.AreEqual(bookingStage.Description, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetNull()
        {
            string test = null;
            bookingStage.Description = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetSpaces()
        {
            string test = "    ";
            bookingStage.Description = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSetEmpty()
        {
            string test = "";
            bookingStage.Description = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            this.bookingStage.Id = testId;
            BookingStage test = new BookingStage();
            test.Id = testId;
            Assert.IsTrue(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.bookingStage.Id = testId1;
            BookingStage test = new BookingStage();
            test.Id = testId2;
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.bookingStage.Id = testId1;
            BookingStage test = new BookingStage();
            test.Id = testId2;
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            this.bookingStage.Id = testId1;
            BookingStage test = null;
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            this.bookingStage.Id = testId1;
            string test = "testing";
            Assert.IsFalse(bookingStage.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            this.bookingStage.Id = testId1;
            Booking test = new Booking();
            Assert.IsFalse(bookingStage.Equals(test));
        }
    }
}