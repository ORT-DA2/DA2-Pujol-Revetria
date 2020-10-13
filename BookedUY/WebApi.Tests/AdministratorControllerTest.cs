using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrations.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

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

            //var mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            //mock.Setup(p => p.GetByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(admin);
            //var controller = new AdministratorController(mock.Object, new SessionLogic());
            //var result = controller.GetAccommodationsInSpot(1) as OkObjectResult;
            //mock.VerifyAll();
            //Assert.AreEqual(200, result.StatusCode);
        }
    }
}
