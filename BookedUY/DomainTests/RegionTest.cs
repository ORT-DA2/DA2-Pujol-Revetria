using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests
{
    [TestClass]
    public class RegionTest
    {
        Region region;
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
            string test = "test";
            region.Name = test;
            Assert.AreEqual(region.Name, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetNull()
        {
            string test = null;
            region.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetEmpty()
        {
            string test = "";
            region.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSetSpaces()
        {
            string test = "   ";
            region.Name = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testName = "test";
            this.region.Id = testId;
            this.region.Name = testName;
            Region test = new Region();
            test.Id = testId;
            test.Name = testName;
            Assert.IsTrue(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName = "test";
            this.region.Id = testId1;
            this.region.Name = testName;
            Region test = new Region();
            test.Id = testId2;
            test.Name = testName;
            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testName1 = "test1";
            string testName2 = "test2";
            this.region.Id = testId1;
            this.region.Name = testName1;
            Region test = new Region();
            test.Id = testId2;
            test.Name = testName2;
            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.region.Id = testId1;
            this.region.Name = testName1;
            Region test = null;
            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.region.Id = testId1;
            this.region.Name = testName1;
            string test = "testing";
            Assert.IsFalse(region.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testName1 = "test";
            this.region.Id = testId1;
            this.region.Name = testName1;
            Booking test = new Booking();
            Assert.IsFalse(region.Equals(test));
        }
    }

}
