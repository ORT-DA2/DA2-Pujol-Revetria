using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class AccommodationTest
    {
        Accommodation accommodation;
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
        public void TestNameSet()
        {
            string test = "test";
            accommodation.Name = test;
            Assert.AreEqual(accommodation.Name, test);
        }

        [TestMethod]
        public void TestInformationSet()
        {
            string test = "test";
            accommodation.Information = test;
            Assert.AreEqual(accommodation.Information, test);
        }

        [TestMethod]
        public void TestPriceSet()
        {
            double test = 1.55;
            accommodation.PricePerNight = test;
            Assert.AreEqual(accommodation.PricePerNight, test);
        }

        [TestMethod]
        [ExpectedException()]
        public void TestPriceSetNegative()
        {
            double test = -1.45;
            accommodation.PricePerNight = test;
            Assert.Fail();
        }
    }
}
