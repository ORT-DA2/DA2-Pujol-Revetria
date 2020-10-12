using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class AccommodationImageTest
    {
        AccommodationImage accommodationImage;
        [TestInitialize]
        public void StartUp()
        {
            accommodationImage = new AccommodationImage();
        }

        [TestCleanup]
        public void CleanUp()
        {
            accommodationImage = new AccommodationImage();
        }

        [TestMethod]
        public void TestImageSet()
        {
            string test = "test";
            accommodationImage.Image = test;
            Assert.AreEqual(accommodationImage.Image, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetNull()
        {
            string test = null;
            accommodationImage.Image = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetEmpty()
        {
            string test = "";
            accommodationImage.Image = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetSpaces()
        {
            string test = "   ";
            accommodationImage.Image = test;
            Assert.Fail();
        }
    }
}
