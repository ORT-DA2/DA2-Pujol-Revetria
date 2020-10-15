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
            string output = "test";
            touristicSpot.Name = output;
            Assert.AreEqual(touristicSpot.Name, output);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet2()
        {
            string output = " ";
            touristicSpot.Name = output;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet3()
        {
            string output = "";
            touristicSpot.Name = output;
            Assert.Fail();
        }

        [TestMethod]
        public void TestDescriptionSet()
        {
            string output = "text";
            touristicSpot.Description = output;
            Assert.AreEqual(touristicSpot.Description, output);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSet2()
        {
            string output = " ";
            touristicSpot.Description = output;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestDescriptionSet3()
        {
            string output = "";
            touristicSpot.Description = output;
            Assert.Fail();
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
            string output = " ";
            Assert.IsFalse(touristicSpot.Equals(output));
        }

        [TestMethod]
        public void TestEquals3()
        {
            TouristicSpot aux = new TouristicSpot();
            aux.Name = "test";
            Assert.IsFalse(touristicSpot.Equals(aux));
        }
    }
}