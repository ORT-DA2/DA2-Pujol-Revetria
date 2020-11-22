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
            this.reportTuple.Id = 1;
            ReportTuple test = new ReportTuple
            {
                Id = 1,
                Count = 1
            };

            Assert.IsTrue(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.reportTuple.Id = 1;
            this.reportTuple.Count = 1;
            ReportTuple test = new ReportTuple
            {
                Id = 2,
                Count = 2
            };

            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.reportTuple.Id = 1;
            this.reportTuple.Count = 1;
            ReportTuple test = new ReportTuple
            {
                Id = 2,
                Count = 2
            };

            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.reportTuple.Id = 1;
            this.reportTuple.Count = 1;
            ReportTuple test = null;

            Assert.IsFalse(reportTuple.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.reportTuple.Id = 1;
            this.reportTuple.Count = 1;

            Assert.IsFalse(reportTuple.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.reportTuple.Id = 1;
            this.reportTuple.Count = 1;
            Booking test = new Booking();

            Assert.IsFalse(reportTuple.Equals(test));
        }
    }
}
