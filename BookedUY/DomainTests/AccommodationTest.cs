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
            accommodation.Address = "test";
            Assert.AreEqual(accommodation.Address, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetNull()
        {
            accommodation.Address = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetEmpty()
        {
            accommodation.Address = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetSpaces()
        {
            accommodation.Address = "   ";
        }

        [TestMethod]
        public void TestNameSet()
        {
            accommodation.Name = "test";
            Assert.AreEqual(accommodation.Name, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            accommodation.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            accommodation.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            accommodation.Name = "   ";
        }

        [TestMethod]
        public void TestInformationSet()
        {
            accommodation.Information = "test";
            Assert.AreEqual(accommodation.Information, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetNull()
        {
            accommodation.Information = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetSpaces()
        {
            accommodation.Information = "    ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestInformationSetEmpty()
        {
            accommodation.Information = "";
        }

        [TestMethod]
        public void TestPriceSet()
        {
            accommodation.PricePerNight = 1.55;
            Assert.AreEqual(accommodation.PricePerNight, 1.55);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativePriceException))]
        public void TestPriceSetNegative()
        {
            accommodation.PricePerNight = -1.45;
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test";
            Accommodation test = new Accommodation
            {
                Id = 1,
                Name = "test"
            };
            Assert.IsTrue(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test";
            Accommodation test = new Accommodation
            {
                Id = 2,
                Name = "test"
            };
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test1";
            Accommodation test = new Accommodation
            {
                Id = 2,
                Name = "test2"
            };
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test1";
            Accommodation test = null;
            Assert.IsFalse(accommodation.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test1";
            Assert.IsFalse(accommodation.Equals("Testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.accommodation.Id = 1;
            this.accommodation.Name = "test1";
            Booking test = new Booking();
            Assert.IsFalse(accommodation.Equals(test));
        }
    }
}