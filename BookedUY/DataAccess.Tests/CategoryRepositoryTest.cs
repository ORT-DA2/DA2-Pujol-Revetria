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

        [TestMethod]
        public void TestAdd()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };
            var repository = new CategoryRepository(_context);
            repository.Add(category);

            Assert.AreEqual(_context.Find<Category>(category.Id), category);
        }

        [TestMethod]
        public void TestDelete()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };

            _context.Add(category);
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);

            repository.Delete(category);

            Assert.IsNull(_context.Find<Category>(category.Id));
        }

        [TestMethod]
        public void TestGetById()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };

            _context.Add(category);
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);

            Assert.AreEqual(_context.Find<Category>(category.Id), category);
        }

        [TestMethod]
        public void TestGetByIdNull()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };

            _context.Add(category);
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);

            Assert.IsNull(_context.Find<Category>(2));
        }

        [TestMethod]
        public void TestGetByNameNull()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };

            _context.Add(category);
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);
            var result = repository.GetByName("a");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetByName()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Playa",
                Spots = null
            };

            _context.Add(category);
            _context.SaveChanges();
            var repository = new CategoryRepository(_context);
            var result = repository.GetByName("Playa");
            Assert.AreEqual(result, category);
        }
    }
}