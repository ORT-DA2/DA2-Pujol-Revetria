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
            this.reportTupleReturn.AccommodationName = "a";
            ReportTupleReturn test = new ReportTupleReturn
            {
                AccommodationName = "a"
            };

            Assert.IsTrue(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.reportTupleReturn.AccommodationName = "a";
            ReportTupleReturn test = new ReportTupleReturn
            {
                AccommodationName = "b"
            };

            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.reportTupleReturn.AccommodationName = "a";
            ReportTupleReturn test = new ReportTupleReturn
            {
                AccommodationName = "b"
            };

            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.reportTupleReturn.AccommodationName = "a";
            ReportTupleReturn test = null;

            Assert.IsFalse(reportTupleReturn.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.reportTupleReturn.AccommodationName = "a";

            Assert.IsFalse(reportTupleReturn.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.reportTupleReturn.AccommodationName = "a";
            Booking test = new Booking();

            Assert.IsFalse(reportTupleReturn.Equals(test));
        }
    }
}