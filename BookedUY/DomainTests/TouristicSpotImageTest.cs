using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class TouristicSpotImageTest
    {
        TouristicSpotImage touristicSpotImage;
        [TestInitialize]
        public void StartUp()
        {
            touristicSpotImage = new TouristicSpotImage();
        }

        [TestCleanup]
        public void CleanUp()
        {
            touristicSpotImage = new TouristicSpotImage();
        }

        [TestMethod]
        public void TestImageSet()
        {
            string test = "test";
            touristicSpotImage.Image = test;
            Assert.AreEqual(touristicSpotImage.Image, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetNull()
        {
            string test = null;
            touristicSpotImage.Image = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestImageSetEmpty()
        {
            string test = "";
            touristicSpotImage.Image = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestAddressSetSpaces()
        {
            string test = "   ";
            touristicSpotImage.Image = test;
            Assert.Fail();
        }
    }
}
