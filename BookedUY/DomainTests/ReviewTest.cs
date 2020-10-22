using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests
{
    [TestClass]
    public class ReviewTest
    {
        private Review review;

        [TestInitialize]
        public void StartUp()
        {
            review = new Review();
        }

        [TestCleanup]
        public void CleanUp()
        {
            review = new Review();
        }

        [TestMethod]
        public void TestScoreSet()
        {
            int test = 1;
            review.Score = test;
            Assert.AreEqual(review.Score, test);
        }

        [TestMethod]
        public void TestScoreSet1()
        {
            int test = 3;
            review.Score = test;
            Assert.AreEqual(review.Score, test);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetNegative()
        {
            int test = -1;
            review.Score = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetPlus5()
        {
            int test = 6;
            review.Score = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetZero()
        {
            int test = 0;
            review.Score = test;
            Assert.Fail();
        }
        [TestMethod]
        public void TestCommentSet()
        {
            string test = "test";
            review.Comment = test;
            Assert.AreEqual(review.Comment, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetNull()
        {
            string test = null;
            review.Comment = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetEmpty()
        {
            string test = "";
            review.Comment = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetSpaces()
        {
            string test = "   ";
            review.Comment = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            this.review.Id = testId;
            Review test = new Review();
            test.Id = testId;
            Assert.IsTrue(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.review.Id = testId1;
            Review test = new Review();
            test.Id = testId2;
            Assert.IsFalse(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            this.review.Id = testId1;
            Review test = null;
            Assert.IsFalse(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            this.review.Id = testId1;
            string test = "testing";
            Assert.IsFalse(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            this.review.Id = testId1;
            Review test = new Review();
            Assert.IsFalse(review.Equals(test));
        }
    }
}
