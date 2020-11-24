using BusinessLogic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SessionInterface;
using System.Collections.Generic;
using WebApi.Controllers;
using WebApi.DTOs;

namespace WebApi.Tests
{
    [TestClass]
    public class AdimistratorControllerTest
    {
        [TestMethod]
        public void TestLoginOK()
        {
            Administrator administrator = new Administrator()
            {
                Email = "s@s.com",
                Password = "password"
            };
            string token = "token";
            var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(administrator);
            var mockSession = new Mock<ISessionLogic>(MockBehavior.Strict);
            mockSession.Setup(p => p.GenerateToken(It.IsAny<Administrator>())).Returns(token);
            var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);

            var result = controller.Login("admin", "123") as OkObjectResult;

            mockAdministrator.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetAllTest()
        {
            Administrator admin = new Administrator()
            {
                Email = "s@s.com",
                Password = "password"
            };
            List<Administrator> expected = new List<Administrator>()
            {
                admin
            };
            var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.GetAll()).Returns(expected);
            var mockSession = new Mock<ISessionLogic>(MockBehavior.Strict);
            var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);

            var result = controller.Get() as OkObjectResult;

            mockAdministrator.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void CreateAdminTest()
        {
            Administrator administrator = new Administrator()
            {
                Email = "s@s.com",
                Password = "password"
            };
            AdministratorModelIn administratorModelIn = new AdministratorModelIn()
            {
                Email = administrator.Email,
                Password = administrator.Password
            };
            string token = "token";
            var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.AddAdministrator(It.IsAny<Administrator>())).Returns(administrator);
            var mockSession = new Mock<ISessionLogic>(MockBehavior.Strict);
            var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);

            var result = controller.CreateAdmin(administratorModelIn) as OkObjectResult;

            mockAdministrator.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void DeleteAdminTest()
        {
            Administrator administrator = new Administrator()
            {
                Email = "s@s.com",
                Password = "password"
            };
            string token = "token";
            var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mockAdministrator.Setup(p => p.Delete(It.IsAny<Administrator>())).Returns(administrator);
            mockAdministrator.Setup(p => p.GetById(It.IsAny<int>())).Returns(administrator);
            var mockSession = new Mock<ISessionLogic>(MockBehavior.Strict);
            var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);

            controller.Delete(1);

            mockAdministrator.VerifyAll();
        }
    }
}