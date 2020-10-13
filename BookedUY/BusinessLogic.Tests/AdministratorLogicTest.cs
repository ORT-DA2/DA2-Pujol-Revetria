using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class AdministratorLogicTest
    {
        [TestMethod]
        public void AddAdministratorTest()
        {
            int testId = 5;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "ab@ab.com";
            administrator.Password = "ab";
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Administrator>())).Returns(administrator);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns<Administrator>(null);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.AddAdministrator(administrator);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void AddAdministratorAlreadyExistsTest()
        {
            int testId = 5;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "ab@ab.com";
            administrator.Password = "ab";
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Administrator>())).Returns(administrator);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.AddAdministrator(administrator);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        public void GetEmailAndPasswordTest()
        {
            int testId = 9;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "a@a.com";
            administrator.Password = "a";
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.GetByEmailAndPassword("a@a.com", "a");
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetEmailAndPasswordNotFoundTest()
        {
            int testId = 9;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "a@a.com";
            administrator.Password = "ab";
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.GetByEmailAndPassword("a@a.com", "a");
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        public void GetAllTest()
        {
            int testId = 9;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "a@a.com";
            administrator.Password = "a";
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(administrators);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(administrator.Equals(administrators.FirstOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            int testId = 2;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "a@a.com";
            administrator.Password = "a";
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            mock.Setup(p => p.Delete(It.IsAny<Administrator>())).Returns(administrator);
            var logic = new AdministratorLogic(mock.Object);
            var result = logic.Delete(administrator);
            mock.VerifyAll();
            Assert.AreEqual(result, administrator);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteExceptionTest()
        {
            int testId = 3;
            Administrator administrator = new Administrator();
            administrator.Id = testId;
            administrator.Email = "a@a.com";
            administrator.Password = "a";
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns<Administrator>(null);
            mock.Setup(p => p.Delete(It.IsAny<Administrator>())).Returns(administrator);
            var logic = new AdministratorLogic(mock.Object);
            logic.Delete(administrator);
            mock.VerifyAll();
        }
    }
}
