using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class ReportTupleReturnTest
    {
        private ReportTupleReturn reportTupleReturn;

        [TestInitialize]
        public void StartUp()
        {
            reportTupleReturn = new ReportTupleReturn();
        }

        [TestCleanup]
        public void CleanUp()
        {
            reportTupleReturn = new ReportTupleReturn();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            string testName = "a";
            this.reportTupleReturn.AccommodationName = testName;
            ReportTupleReturn test = new ReportTupleReturn();
            test.AccommodationName = testName;
            Assert.IsTrue(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            string testName = "a";
            string testName2 = "b";
            this.reportTupleReturn.AccommodationName = testName;
            ReportTupleReturn test = new ReportTupleReturn();
            test.AccommodationName = testName2;
            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            string testName = "a";
            string testName2 = "b";
            this.reportTupleReturn.AccommodationName = testName;
            ReportTupleReturn test = new ReportTupleReturn();
            test.AccommodationName = testName2;
            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            string testName = "a";
            this.reportTupleReturn.AccommodationName = testName;
            ReportTupleReturn test = null;
            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            string testName = "a";
            this.reportTupleReturn.AccommodationName = testName;
            string test = "testing";
            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            string testName = "a";
            this.reportTupleReturn.AccommodationName = testName;
            Booking test = new Booking();
            Assert.IsFalse(reportTupleReturn.Equals(test));
        }
    }
}