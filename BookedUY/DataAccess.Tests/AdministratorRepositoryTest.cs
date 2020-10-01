using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Tests
{
    [TestClass]
    public class AdministratorRepositoryTest
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
        public void TestGetAllAdministrator()
        {
            List<Administrator> administratorsToReturn = new List<Administrator>()
                {
                    new Administrator()
                    {
                        Id = 1,
                        Email = "prueba@prueba.com",
                        Password = "P@5Sw0rd"
                    },
                    new Administrator()
                    {
                        Id=2,
                        Email = "prueba2@prueba2.com",
                        Password = "P@5Sw0rd3"
                    },
                    new Administrator()
                    {
                        Id=3,
                        Email = "prueba3@prueba3.com",
                        Password = "P@5Sw0rd3"
                    },
                };
            administratorsToReturn.ForEach(a => _context.Add(a));
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(administratorsToReturn.SequenceEqual(result));
        }
    }
}
