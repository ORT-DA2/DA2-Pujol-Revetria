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
            administrator.Email = "facundo@gmail.com";

            Assert.AreEqual(administrator.Email, "facundo@gmail.com");
        }

        [TestMethod]
        public void TestEmailSet2()
        {
            administrator.Email = "test.test@com";

            Assert.AreEqual(administrator.Email, "test.test@com");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetNull()
        {
            administrator.Email = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetEmpty()
        {
            administrator.Email = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetSpaces()
        {
            administrator.Email = "   ";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail()
        {
            administrator.Email = "test";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail2()
        {
            administrator.Email = "test@@@abc";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail3()
        {
            administrator.Email = "test.test@.com";
        }

        [TestMethod]
        public void TestPasswordSet()
        {
            administrator.Password = "test";

            Assert.AreEqual(administrator.Password, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetNull()
        {
            administrator.Password = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetEmpty()
        {
            administrator.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestPasswordSetSpaces()
        {
            administrator.Password = "   ";
        }

        [TestMethod]
        public void TestEqualsExpectedTrue()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";
            Administrator test = new Administrator
            {
                Id = 1,
                Email = "facundo@gmail.com"
            };

            Assert.IsTrue(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";
            Administrator test = new Administrator
            {
                Id = 2,
                Email = "facundo@gmail.com"
            };

            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";
            Administrator test = new Administrator
            {
                Id = 2,
                Email = "javier@gmail.com"
            };

            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";
            Administrator test = null;

            Assert.IsFalse(administrator.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";

            Assert.IsFalse(administrator.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            this.administrator.Id = 1;
            this.administrator.Email = "facundo@gmail.com";
            Booking test = new Booking();

            Assert.IsFalse(administrator.Equals(test));
        }
    }
}