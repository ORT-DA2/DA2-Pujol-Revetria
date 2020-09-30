using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Tests
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id=1,
                    Name="Playa",
                    Spots = null
                },
                new Category()
                {
                    Id=2,
                    Name="Pradera",
                    Spots = null
                },
            };
            var options = new DbContextOptionsBuilder<BookedUYContext>()
                .UseInMemoryDatabase(databaseName: "BookedUYDB").Options;
            var context = new BookedUYContext(options);
            categoriesToReturn.ForEach(r => context.Add(r));
            context.SaveChanges();
            var repository = new CategoryRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(categoriesToReturn.SequenceEqual(result));
        }
    }
}