using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class CategoryLogicTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            int testId = 5;
            List<Category> categories = new List<Category>();
            Category category = new Category();
            category.Id = testId;
            category.Name = "Beach";
            categories.Add(category);
            var mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(categories);
            var logic = new CategoryLogic(mock.Object);
            var result = logic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(categories));
        }

        [TestMethod]
        public void GetAllNullTest()
        {
            List<Category> categories = new List<Category>();
            var mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(categories);
            var logic = new CategoryLogic(mock.Object);
            var result = logic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(categories));
        }
    }
}
