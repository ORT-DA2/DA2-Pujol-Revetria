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
    }
}
