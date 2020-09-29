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
            string testAddress = "test";
            accommodation.Address = testAddress;
            Assert.AreEqual(accommodation.Address, testAddress);
        }
    }
}
