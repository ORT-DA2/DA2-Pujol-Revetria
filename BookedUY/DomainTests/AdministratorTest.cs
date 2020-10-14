using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class AdministratorTest
    {
        private Administrator administrator;

        [TestInitialize]
        public void StartUp()
        {
            administrator = new Administrator();
        }

        [TestCleanup]
        public void CleanUp()
        {
            administrator = new Administrator();
        }

        [TestMethod]
        public void TestEmailSet()
        {
            string test = "facundo@gmail.com";
            administrator.Email = test;
            Assert.AreEqual(administrator.Email, test);
        }

        [TestMethod]
        public void TestEmailSet2()
        {
            string test = "test.test@com";
            administrator.Email = test;
            Assert.AreEqual(administrator.Email, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetNull()
        {
            string test = null;
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetEmpty()
        {
            string test = "";
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetSpaces()
        {
            string test = "   ";
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail()
        {
            string test = "test";
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail2()
        {
            string test = "test@@@abc";
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail3()
        {
            string test = "test.test@.com";
            administrator.Email = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestPasswordSet()
        {
            string test = "test";
            administrator.Password = test;
            Assert.AreEqual(administrator.Password, test);
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetNull()
        {
            string test = null;
            administrator.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetEmpty()
        {
            string test = "";
            administrator.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetSpaces()
        {
            string test = "   ";
            administrator.Password = test;
            Assert.Fail();
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            int testId = 1;
            string testEmail = "facundo@gmail.com";
            this.administrator.Id = testId;
            this.administrator.Email = testEmail;
            Administrator test = new Administrator();
            test.Id = testId;
            test.Email = testEmail;
            Assert.IsTrue(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail = "facundo@gmail.com";
            this.administrator.Id = testId1;
            this.administrator.Email = testEmail;
            Administrator test = new Administrator();
            test.Id = testId2;
            test.Email = testEmail;
            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            int testId1 = 1;
            int testId2 = 2;
            string testEmail1 = "facundo@gmail.com";
            string testEmail2 = "javier@gmail.com";
            this.administrator.Id = testId1;
            this.administrator.Email = testEmail1;
            Administrator test = new Administrator();
            test.Id = testId2;
            test.Email = testEmail2;
            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.administrator.Id = testId1;
            this.administrator.Email = testEmail1;
            Administrator test = null;
            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.administrator.Id = testId1;
            this.administrator.Email = testEmail1;
            string test = "testing";
            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            int testId1 = 1;
            string testEmail1 = "facundo@gmail.com";
            this.administrator.Id = testId1;
            this.administrator.Email = testEmail1;
            Booking test = new Booking();
            Assert.IsFalse(administrator.Equals(test));
        }
    }
}