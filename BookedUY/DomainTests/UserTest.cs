using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTests
{
    [TestClass]
    public class UserTest
    {
        User user;

        [TestInitialize]
        public void StartUp()
        {
            user = new User();
        }

        [TestCleanup]
        public void CleanUp()
        {
            user = new User();
        }
        [TestMethod]
        public void TestNameSet()
        {
            string output = "text";
            user.Name = output;
            Assert.AreEqual(user.Name, output);
        }
        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet2()
        {
            string output = " ";
            user.Name = output;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet3()
        {
            string output = "";
            user.Name = output;
            Assert.Fail();
        }

        public void TestLastNameSet()
        {
            string output = "text";
            user.LastName = output;
            Assert.AreEqual(user.LastName, output);
        }

        [TestMethod]
        public void TestEmailSet()
        {
            string test = "facundo@gmail.com";
            user.Email = test;
            Assert.AreEqual(user.Email, test);
        }

        [TestMethod]
        public void TestEmailSet2()
        {
            string test = "test.test@com";
            user.Email = test;
            Assert.AreEqual(user.Email, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetNull()
        {
            string test = null;
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetEmpty()
        {
            string test = "";
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetSpaces()
        {
            string test = "   ";
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail()
        {
            string test = "test";
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail2()
        {
            string test = "test@@@abc";
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail3()
        {
            string test = "test.test@.com";
            user.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestPasswordSet()
        {
            string test = "test";
            user.Password = test;
            Assert.AreEqual(user.Password,test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetNull()
        {
            string test = null;
            user.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetEmpty()
        {
            string test = "";
            user.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetSpaces()
        {
            string test = "   ";
            user.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testEmail = "facundo@gmail.com";
            this.user.Id = testId;
            this.user.Email = testEmail;
            User test = new User();
            test.Id = testId;
            test.Email = testEmail;
            Assert.IsTrue(user.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail = "facundo@gmail.com";
            this.user.Id = testId1;
            this.user.Email = testEmail;
            User test = new User();
            test.Id = testId2;
            test.Email = testEmail;
            Assert.IsFalse(user.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail1 = "facundo@gmail.com";
            string testEmail2 = "javier@gmail.com";
            this.user.Id = testId1;
            this.user.Email = testEmail1;
            User test = new User();
            test.Id = testId2;
            test.Email = testEmail2;
            Assert.IsFalse(user.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.user.Id = testId1;
            this.user.Email = testEmail1;
            User test = null;
            Assert.IsFalse(user.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.user.Id = testId1;
            this.user.Email = testEmail1;
            string test = "testing";
            Assert.IsFalse(user.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.user.Id = testId1;
            this.user.Email = testEmail1;
            Booking test = new Booking();
            Assert.IsFalse(user.Equals(test));
        }
    }
}
