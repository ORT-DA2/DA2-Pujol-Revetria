using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class TouristTest
    {
        private Tourist tourist;

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
            tourist.Name = "text";
            Assert.AreEqual(tourist.Name, "text");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet2()
        {
            tourist.Name = " ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestNameSet3()
        {
            tourist.Name = "";
        }

        public void TestLastNameSet()
        {
            tourist.LastName = "text";
            Assert.AreEqual(tourist.LastName, "text");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestLastNameSet2()
        {
            tourist.LastName = " ";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestLastNameSet3()
        {
            tourist.LastName = "";
        }

        [TestMethod]
        public void TestEmailSet()
        {
            tourist.Email = "facundo@gmail.com";
            Assert.AreEqual(tourist.Email, "facundo@gmail.com");
        }

        [TestMethod]
        public void TestEmailSet2()
        {
            tourist.Email = "test.test@com";
            Assert.AreEqual(tourist.Email, "test.test@com");
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetNull()
        {
            tourist.Email = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetEmpty()
        {
            tourist.Email = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void TestEmailSetSpaces()
        {
            tourist.Email = "   ";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail()
        {
            tourist.Email = "test";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail2()
        {
            tourist.Email = "test@@@abc";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailException))]
        public void TestEmailSetFail3()
        {
            tourist.Email = "test.test@.com";
        }

        public void TestEqualsExpectedTrue()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Tourist test = new Tourist
            {
                Id = 1,
                Email = "facundo@gmail.com"
            };
            Assert.IsTrue(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Tourist test = new Tourist
            {
                Id = 2,
                Email = "facundo@gmail.com"
            };
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalse2()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Tourist test = new Tourist
            {
                Id = 2,
                Email = "javier@gmail.com"
            };
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNull()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Tourist test = null;
            Assert.IsFalse(tourist.Equals(test));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Assert.IsFalse(tourist.Equals("testing"));
        }

        [TestMethod]
        public void TestEqualsExpectedFalseNotType2()
        {
            tourist.Id = 1;
            tourist.Email = "facundo@gmail.com";
            Booking test = new Booking();
            Assert.IsFalse(tourist.Equals(test));
        }
    }
}