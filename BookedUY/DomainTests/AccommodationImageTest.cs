using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class AccommodationImageTest
    {
        private AccommodationImage accommodationImage;

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
            accommodationImage.Image = "test";
            accommodationImage.AccommodationId = 0;
            accommodationImage.Id = 0;
            accommodationImage.Accommodation = new Accommodation();

            Assert.AreEqual(accommodationImage.Image, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetNull()
        {
            accommodationImage.Image = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetEmpty()
        {
            accommodationImage.Image = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetSpaces()
        {
            accommodationImage.Image = "   ";
        }
    }
}