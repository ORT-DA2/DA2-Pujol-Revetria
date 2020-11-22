using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class TouristicSpotTest
    {
        private TouristicSpot touristicSpot;

        [TestInitialize]
        public void StartUp()
        {
            touristicSpot = new TouristicSpot();
        }

        [TestCleanup]
        public void CleanUp()
        {
            touristicSpot = new TouristicSpot();
        }

        [TestMethod]
        public void TestNameSet()
        {
            touristicSpot.Name = "test";

            Assert.AreEqual(touristicSpot.Name, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet2()
        {
            touristicSpot.Name = " ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet3()
        {
            touristicSpot.Name = "";
        }

        [TestMethod]
        public void TestDescriptionSet()
        {
            touristicSpot.Description = "text";

            Assert.AreEqual(touristicSpot.Description, "text");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSet2()
        {
            touristicSpot.Description = " ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSet3()
        {
            touristicSpot.Description = "";
        }

        [TestMethod]
        public void TestEquals()
        {
            TouristicSpot aux = touristicSpot;

            Assert.IsTrue(touristicSpot.Equals(aux));
        }

        [TestMethod]
        public void TestEquals2()
        {
            Assert.IsFalse(touristicSpot.Equals(" "));
        }

        [TestMethod]
        public void TestEquals3()
        {
            TouristicSpot aux = new TouristicSpot
            {
                Name = "test"
            };

            Assert.IsFalse(touristicSpot.Equals(aux));
        }
    }
}