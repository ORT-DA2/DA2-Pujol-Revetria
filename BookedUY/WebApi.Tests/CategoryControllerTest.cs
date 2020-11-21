using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class CategoryControllerTest
    {
        [TestMethod]
        public void TestGetAccommodationsInSpotOK()
        {
            Category category = new Category()
            {
                Name = "Test name",
                Id = 1
            };
            List<Category> expected = new List<Category>()
            {
                category
            };
            var mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(expected);
            var controller = new CategoryController(mock.Object);

            var result = controller.Get() as OkObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
