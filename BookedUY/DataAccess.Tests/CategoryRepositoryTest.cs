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
        private DbContextOptions<BookedUYContext> _options = new DbContextOptionsBuilder<BookedUYContext>()
                .UseInMemoryDatabase(databaseName: "BookedUYDB").Options;
        private BookedUYContext _context;

        [TestInitialize]
        public void TestInit()
        {
            _context = new BookedUYContext(_options);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }

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

            categoriesToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(categoriesToReturn.SequenceEqual(result));
        }
    }
}