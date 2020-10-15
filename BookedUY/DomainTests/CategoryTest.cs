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
            string test = "test";
            category.Name = test;
            Assert.AreEqual(category.Name, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            string test = null;
            category.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            string test = "";
            category.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            string test = "   ";
            category.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testName = "test";
            this.category.Id = testId;
            this.category.Name = testName;
            Category test = new Category();
            test.Id = testId;
            test.Name = testName;
            Assert.IsTrue(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName = "test";
            this.category.Id = testId1;
            this.category.Name = testName;
            Category test = new Category();
            test.Id = testId2;
            test.Name = testName;
            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName1 = "test1";
            string testName2 = "test2";
            this.category.Id = testId1;
            this.category.Name = testName1;
            Category test = new Category();
            test.Id = testId2;
            test.Name = testName2;
            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.category.Id = testId1;
            this.category.Name = testName1;
            Category test = null;
            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.category.Id = testId1;
            this.category.Name = testName1;
            string test = "testing";
            Assert.IsFalse(category.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.category.Id = testId1;
            this.category.Name = testName1;
            Booking test = new Booking();
            Assert.IsFalse(category.Equals(test));
        }
    }
}