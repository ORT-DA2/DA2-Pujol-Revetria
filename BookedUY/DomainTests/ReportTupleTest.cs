using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class ReportTupleTest
    {
        private ReportTuple reportTuple;

        [TestInitialize]
        public void StartUp()
        {
            reportTuple = new ReportTuple();
        }

        [TestCleanup]
        public void CleanUp()
        {
            reportTuple = new ReportTuple();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            this.reportTuple.Id = testId;
            ReportTuple test = new ReportTuple();
            test.Id = testId;
            test.Count = testId;
            Assert.IsTrue(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.reportTuple.Id = testId1;
            this.reportTuple.Count = testId1;
            ReportTuple test = new ReportTuple();
            test.Id = testId2;
            test.Count = testId2;
            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            this.reportTuple.Id = testId1;
            this.reportTuple.Count = testId1;
            ReportTuple test = new ReportTuple();
            test.Id = testId2;
            test.Count = testId2;
            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            this.reportTuple.Id = testId1;
            this.reportTuple.Count = testId1;
            ReportTuple test = null;
            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            this.reportTuple.Id = testId1;
            this.reportTuple.Count = testId1;
            string test = "testing";
            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            this.reportTuple.Id = testId1;
            this.reportTuple.Count = testId1;
            Booking test = new Booking();
            Assert.IsFalse(reportTuple.Equals(test));
        }
    }
}
