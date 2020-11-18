using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class AdministratorLogicTest
    {
        [TestMethod]
        public void AddAdministratorTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 5,
                Email = "ab@ab.com",
                Password = "ab"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.Add(It.IsAny<Administrator>())).Returns(administrator);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns<Administrator>(null);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.AddAdministrator(administrator);

            mockAdministrator.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void AddAdministratorAlreadyExistsTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 5,
                Email = "ab@ab.com",
                Password = "ab"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.Add(It.IsAny<Administrator>())).Returns(administrator);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.AddAdministrator(administrator);
        }

        [TestMethod]
        public void GetEmailAndPasswordTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 9,
                Email = "a@a.com",
                Password = "a"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.GetByEmailAndPassword("a@a.com", "a");

            mockAdministrator.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetEmailAndPasswordNotFoundTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 9,
                Email = "a@a.com",
                Password = "ab"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.GetByEmailAndPassword("a@a.com", "a");
        }

        [TestMethod]
        public void GetAllTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 9,
                Email = "a@a.com",
                Password = "a"
            };
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetAll()).Returns(administrators);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.GetAll();

            mockAdministrator.VerifyAll();
            Assert.IsTrue(administrator.Equals(administrators.FirstOrDefault()));
        }

        [TestMethod]
        public void DeleteTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 2,
                Email = "a@a.com",
                Password = "a"
            };
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(administrator);
            mockAdministrator.Setup(p => p.Delete(It.IsAny<Administrator>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.Delete(administrator);

            mockAdministrator.VerifyAll();
            Assert.AreEqual(result, administrator);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteExceptionTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 3,
                Email = "a@a.com",
                Password = "a"
            };
            List<Administrator> administrators = new List<Administrator>();
            administrators.Add(administrator);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns<Administrator>(null);
            mockAdministrator.Setup(p => p.Delete(It.IsAny<Administrator>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            logic.Delete(administrator);
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void GetByIdExceptionTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 5,
                Email = "ab@ab.com",
                Password = "ab"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.Add(It.IsAny<Administrator>())).Returns(administrator);
            mockAdministrator.Setup(p => p.GetById(It.IsAny<int>())).Returns<Administrator>(null);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.GetById(5);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Administrator administrator = new Administrator
            {
                Id = 5,
                Email = "ab@ab.com",
                Password = "ab"
            };
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetById(It.IsAny<int>())).Returns(administrator);
            var logic = new AdministratorLogic(mockAdministrator.Object);

            var result = logic.GetById(5);

            mockAdministrator.VerifyAll();
            Assert.IsTrue(result.Equals(administrator));
        }
    }
}