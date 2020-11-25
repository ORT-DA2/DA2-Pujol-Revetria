using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void DeleteAdministratorTest()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            _context.Add(administrator);
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            repository.Delete(administrator);

            Assert.IsNull(_context.Find<Administrator>(1));
        }

        [TestMethod]
        public void TestAddBooking()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            var repository = new AdministratorRepository(_context);

            repository.AddAndSave(administrator);

            Assert.AreEqual(_context.Find<Administrator>(1), administrator);
        }

        [TestMethod]
        public void TestGetByEmail()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<Administrator> administrators = new List<Administrator>()
            {
                administrator,
                new Administrator()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };
            administrators.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            var result = repository.GetByEmail("prueba3@prueba3.com");

            Assert.IsTrue(administrator.Equals(result));
        }

        [TestMethod]
        public void TestGetByEmailNull()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<Administrator> administrators = new List<Administrator>()
            {
                administrator,
                new Administrator()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };
            administrators.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            var result = repository.GetByEmail("prueb@prue.com");

            Assert.IsNull(result);
        }


        [TestMethod]
        public void TestGetById()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<Administrator> administrators = new List<Administrator>()
            {
                administrator,
                new Administrator()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };
            administrators.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            var result = repository.GetById(1);

            Assert.AreEqual(result, administrator);
        }

        [TestMethod]
        public void TestGetByIdNull()
        {
            Administrator administrator = new Administrator()
            {
                Id = 1,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<Administrator> administrators = new List<Administrator>()
            {
                administrator,
                new Administrator()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };
            administrators.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AdministratorRepository(_context);

            var result = repository.GetById(5);

            Assert.IsNull(result);
        }
    }
}