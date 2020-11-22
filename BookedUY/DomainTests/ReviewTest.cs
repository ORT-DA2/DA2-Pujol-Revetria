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
            review.Score = 1;

            Assert.AreEqual(review.Score, 1);
        }

        [TestMethod]
        public void TestScoreSet1()
        {
            review.Score = 3;

            Assert.AreEqual(review.Score, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetNegative()
        {
            review.Score = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetPlus5()
        {
            review.Score = 9;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScoreException))]
        public void TestScoreSetZero()
        {
            review.Score = 0;
        }
        [TestMethod]
        public void TestCommentSet()
        {
            review.Comment = "test";

            Assert.AreEqual(review.Comment, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetNull()
        {
            review.Comment = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetEmpty()
        {
            review.Comment = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestCommentSetSpaces()
        {
            review.Comment = "   ";
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.review.Id = 1;
            Review test = new Review
            {
                Id = 1
            };

            Assert.IsTrue(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.review.Id = 1;
            Review test = new Review
            {
                Id = 2
            };

            Assert.IsFalse(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.review.Id = 1;
            Review test = null;

            Assert.IsFalse(review.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.review.Id = 1;

            Assert.IsFalse(review.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.review.Id = 1;
            Review test = new Review();

            Assert.IsFalse(review.Equals(test));
        }
    }
}
