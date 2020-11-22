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
            List<Category> categories = new List<Category>();
            Category category = new Category
            {
                Id = 5,
                Name = "Beach"
            };
            categories.Add(category);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetAll()).Returns(categories);
            var logic = new CategoryLogic(mockCategory.Object);

            var result = logic.GetAll();

            mockCategory.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(categories));
        }

        [TestMethod]
        public void GetAllNullTest()
        {
            List<Category> categories = new List<Category>();
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetAll()).Returns(categories);
            var logic = new CategoryLogic(mockCategory.Object);

            var result = logic.GetAll();

            mockCategory.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(categories));
        }
    }
}