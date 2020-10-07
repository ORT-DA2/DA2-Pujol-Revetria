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
    public class UserRepositoryTest
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
        public void TestGetAllUser()
        {
            List<User> administratorsToReturn = new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Email = "prueba@prueba.com",
                        Password = "P@5Sw0rd"
                    },
                    new User()
                    {
                        Id=2,
                        Email = "prueba2@prueba2.com",
                        Password = "P@5Sw0rd3"
                    },
                    new User()
                    {
                        Id=3,
                        Email = "prueba3@prueba3.com",
                        Password = "P@5Sw0rd3"
                    },
                };
            administratorsToReturn.ForEach(a => _context.Add(a));
            _context.SaveChanges();
            var repository = new UserRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(administratorsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            int id = 1;
            User administrator = new User()
            {
                Id = id,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            _context.Add(administrator);
            _context.SaveChanges();
            var repository = new UserRepository(_context);

            repository.Delete(administrator);

            Assert.IsNull(_context.Find<User>(id));
        }

        [TestMethod]
        public void TestAddUser()
        {
            int id = 1;
            User administrator = new User()
            {
                Id = id,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };

            var repository = new UserRepository(_context);
            repository.Add(administrator);

            Assert.AreEqual(_context.Find<User>(id), administrator);

        }

        [TestMethod]
        public void TestGetByEmail()
        {
            int id = 1;
            User admin = new User()
            {
                Id = id,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<User> admins = new List<User>()
            {
                admin,
                new User()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };

            admins.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new UserRepository(_context);
            var result = repository.GetByEmail("prueba3@prueba3.com");
            Assert.IsTrue(admin.Equals(result));
        }

        [TestMethod]
        public void TestGetByEmailNull()
        {
            int id = 1;
            User admin = new User()
            {
                Id = id,
                Email = "prueba3@prueba3.com",
                Password = "P@5Sw0rd3"
            };
            List<User> admins = new List<User>()
            {
                admin,
                new User()
                {
                    Id=2,
                    Email = "prueba2@prueba2.com",
                    Password = "P@5Sw0rd3"
                },
            };

            admins.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new UserRepository(_context);
            var result = repository.GetByEmail("prueb@prue.com");
            Assert.IsNull(result);
        }
    }
}
