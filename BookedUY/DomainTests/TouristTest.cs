using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace DomainTests
{
    [TestClass]
    public class TouristTest
    {
        Tourist tourist;
        [TestInitialize]
        public void StartUp()
        {
            tourist = new Tourist();
        }

        [TestCleanup]
        public void CleanUp()
        {
            tourist = new Tourist();
        }

        [TestMethod]
        public void TestNameSet()
        {
            string output = "text";
            tourist.Name = output;
            Assert.AreEqual(tourist.Name, output);
        }
        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet2()
        {
            string output = " ";
            tourist.Name = output;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet3()
        {
            string output = "";
            tourist.Name = output;
            Assert.Fail();
        }

        public void TestLastNameSet()
        {
            string output = "text";
            tourist.LastName = output;
            Assert.AreEqual(tourist.LastName, output);
        }
        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestLastNameSet2()
        {
            string output = " ";
            tourist.LastName = output;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestLastNameSet3()
        {
            string output = "";
            tourist.LastName = output;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEmailSet()
        {
            string test = "facundo@gmail.com";
            tourist.Email = test;
            Assert.AreEqual(tourist.Email, test);
        }

        [TestMethod]
        public void TestEmailSet2()
        {
            string test = "test.test@com";
            tourist.Email = test;
            Assert.AreEqual(tourist.Email, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetNull()
        {
            string test = null;
            tourist.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetEmpty()
        {
            string test = "";
            tourist.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetSpaces()
        {
            string test = "   ";
            tourist.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail()
        {
            string test = "test";
            tourist.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail2()
        {
            string test = "test@@@abc";
            tourist.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail3()
        {
            string test = "test.test@.com";
            tourist.Email = test;
            Assert.Fail();
        }

        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testEmail = "facundo@gmail.com";
            tourist.Id = testId;
            tourist.Email = testEmail;
            Tourist test = new Tourist();
            test.Id = testId;
            test.Email = testEmail;
            Assert.IsTrue(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail = "facundo@gmail.com";
            tourist.Id = testId1;
            tourist.Email = testEmail;
            Tourist test = new Tourist();
            test.Id = testId2;
            test.Email = testEmail;
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail1 = "facundo@gmail.com";
            string testEmail2 = "javier@gmail.com";
            tourist.Id = testId1;
            tourist.Email = testEmail1;
            Tourist test = new Tourist();
            test.Id = testId2;
            test.Email = testEmail2;
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            tourist.Id = testId1;
            tourist.Email = testEmail1;
            Tourist test = null;
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            tourist.Id = testId1;
            tourist.Email = testEmail1;
            string test = "testing";
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            tourist.Id = testId1;
            tourist.Email = testEmail1;
            Booking test = new Booking();
            Assert.IsFalse(tourist.Equals(test));
        }
    }
}
