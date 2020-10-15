using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class AccommodationTest
    {
        private Accommodation accommodation;

        [TestInitialize]
        public void StartUp()
        {
            accommodation = new Accommodation();
        }

        [TestCleanup]
        public void CleanUp()
        {
            accommodation = new Accommodation();
        }

        [TestMethod]
        public void TestAddressSet()
        {
            string test = "test";
            accommodation.Address = test;
            Assert.AreEqual(accommodation.Address, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetNull()
        {
            string test = null;
            accommodation.Address = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetEmpty()
        {
            string test = "";
            accommodation.Address = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetSpaces()
        {
            string test = "   ";
            accommodation.Address = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestNameSet()
        {
            string test = "test";
            accommodation.Name = test;
            Assert.AreEqual(accommodation.Name, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            string test = null;
            accommodation.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            string test = "";
            accommodation.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            string test = "   ";
            accommodation.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestInformationSet()
        {
            string test = "test";
            accommodation.Information = test;
            Assert.AreEqual(accommodation.Information, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetNull()
        {
            string test = null;
            accommodation.Information = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetSpaces()
        {
            string test = "    ";
            accommodation.Information = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetEmpty()
        {
            string test = "";
            accommodation.Information = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestPriceSet()
        {
            double test = 1.55;
            accommodation.PricePerNight = test;
            Assert.AreEqual(accommodation.PricePerNight, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativePriceException))]
        public void TestPriceSetNegative()
        {
            double test = -1.45;
            accommodation.PricePerNight = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testName = "test";
            this.accommodation.Id = testId;
            this.accommodation.Name = testName;
            Accommodation test = new Accommodation();
            test.Id = testId;
            test.Name = testName;
            Assert.IsTrue(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName = "test";
            this.accommodation.Id = testId1;
            this.accommodation.Name = testName;
            Accommodation test = new Accommodation();
            test.Id = testId2;
            test.Name = testName;
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName1 = "test1";
            string testName2 = "test2";
            this.accommodation.Id = testId1;
            this.accommodation.Name = testName1;
            Accommodation test = new Accommodation();
            test.Id = testId2;
            test.Name = testName2;
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testName1 = "test1";
            this.accommodation.Id = testId1;
            this.accommodation.Name = testName1;
            Accommodation test = null;
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testName1 = "test1";
            this.accommodation.Id = testId1;
            this.accommodation.Name = testName1;
            string test = "testing";
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testName1 = "test1";
            this.accommodation.Id = testId1;
            this.accommodation.Name = testName1;
            Booking test = new Booking();
            Assert.IsFalse(accommodation.Equals(test));
        }
    }
}