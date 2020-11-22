using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class RegionTest
    {
        private Region region;

        [TestInitialize]
        public void StartUp()
        {
            region = new Region();
        }

        [TestCleanup]
        public void CleanUp()
        {
            region = new Region();
        }

        [TestMethod]
        public void TestNameSet()
        {
            region.Name = "test";

            Assert.AreEqual(region.Name, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            region.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            region.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            region.Name = "   ";
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.region.Id = 1;
            this.region.Name = "test";
            Region test = new Region
            {
                Id = 1,
                Name = "test"
            };

            Assert.IsTrue(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.region.Id = 1;
            this.region.Name = "test";
            Region test = new Region
            {
                Id = 2,
                Name = "test"
            };

            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.region.Id = 1;
            this.region.Name = "test1";
            Region test = new Region
            {
                Id = 2,
                Name = "test2"
            };

            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.region.Id = 1;
            this.region.Name = "test";
            Region test = null;

            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.region.Id = 1;
            this.region.Name = "test";

            Assert.IsFalse(region.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.region.Id = 1;
            this.region.Name = "test";
            Booking test = new Booking();

            Assert.IsFalse(region.Equals(test));
        }
    }
}