using BusinessLogic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class AdimistratorControllerTest
    {
        [TestMethod]
        public void TestLoginOK()
        {
            Administrator admin = new Administrator()
            {
                Email = "s@s.com",
                Password = "password"
            };
            string token = "token";

            //var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            //mockAdministrator.Setup(p => p.GetByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(admin);
            //var mockSession = new Mock<SessionLogic>(MockBehavior.Strict);
            //var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);
            //var result = controller.Login("admin", "123") as OkObjectResult;
            //mockAdministrator.VerifyAll();
            //Assert.AreEqual(200, result.StatusCode);
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
            //var mockAdministrator = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            //mockAdministrator.Setup(p => p.GetAll()).Returns(expected);
            //var mockSession = new Mock<SessionLogic>(MockBehavior.Strict);
            //var controller = new AdministratorController(mockAdministrator.Object, mockSession.Object);
            //var result = controller.Get() as OkObjectResult;
            //mockAdministrator.VerifyAll();
            //Assert.AreEqual(200, result.StatusCode);
        }
    }
}