using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class CategoryTest
    {
        private Category category;

        [TestInitialize]
        public void StartUp()
        {
            category = new Category();
        }

        [TestCleanup]
        public void CleanUp()
        {
            category = new Category();
        }

        [TestMethod]
        public void TestNameSet()
        {
            category.Name = "test";

            Assert.AreEqual(category.Name, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            category.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            category.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            category.Name = "   ";
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.category.Id = 1;
            this.category.Name = "test";
            Category test = new Category
            {
                Id = 1,
                Name = "test"
            };

            Assert.IsTrue(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.category.Id = 1;
            this.category.Name = "test";
            Category test = new Category
            {
                Id = 2,
                Name = "test"
            };

            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.category.Id = 1;
            this.category.Name = "test1";
            Category test = new Category
            {
                Id = 2,
                Name = "test2"
            };

            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.category.Id = 1;
            this.category.Name = "test";
            Category test = null;

            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.category.Id = 1;
            this.category.Name = "test";

            Assert.IsFalse(category.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.category.Id = 1;
            this.category.Name = "test";
            Booking test = new Booking();

            Assert.IsFalse(category.Equals(test));
        }
    }
}