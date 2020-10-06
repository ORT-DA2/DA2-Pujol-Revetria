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
    public class TouristRepositoryTest
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
        public void TestGetAllTouristsOk()
        {
            List<Tourist> touristsToReturn = new List<Tourist>()
            {
                new Tourist()
                {
                    Id=1,
                    Name="Juan",
                    LastName="Perez",
                    Email="juanperez@gmail.com",
                    Bookings=null,
                },
                new Tourist()
                {
                    Id=2,
                    Name="Pepe",
                    LastName="Lopez",
                    Email="pepelopez@gmail.com",
                    Bookings=null,
                },
            };

            touristsToReturn.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristRepository(_context);
            var result = repository.GetAll();
            Assert.IsTrue(touristsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddTourist()
        {
            int id = 3;
            Tourist tourist = new Tourist()
            {
                Id = id,
                Name = "Pepe",
                LastName = "Lopez",
                Email = "pepelopez@gmail.com",
                Bookings = null,
            };
            var repository = new TouristRepository(_context);
            repository.Add(tourist);

            Assert.AreEqual(_context.Find<Tourist>(id), tourist);
        }

        [TestMethod]
        public void TestGetByIdTourist()
        {
            int testId = 1;
            Tourist testTourist = new Tourist()
            {
                Id = testId,
                Name = "Pepe",
                LastName = "Lopez",
                Email = "pepelopez@gmail.com",
                Bookings = null,
            };
            List<Tourist> touristList = new List<Tourist>()
            {

                new Tourist()
                {
                    Id=2,
                    Name="Pepe",
                    LastName="Lopez",
                    Email="pepe00lopez@gmail.com",
                    Bookings=null,
                },
            };
            touristList.Add(testTourist);
            touristList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new TouristRepository(_context);

            var result = repository.GetById(testId);

            Assert.AreEqual(testTourist, result);
        }

        [TestMethod]
        public void DeleteTouristsTest()
        {
            int id = 1;
            Tourist tourist = new Tourist()
            {
                Id = id,
                Name = "Pedro",
                LastName = "Korea",
                Email = "pedroKora@gmail.com",
                Bookings = null,
            };
            _context.Add(tourist);
            _context.SaveChanges();
            var repository = new TouristRepository(_context);

            repository.Delete(tourist);

            Assert.IsNull(_context.Find<Tourist>(id));
        }

        [TestMethod]
        public void TestGetByEmailNull()
        {
            int testId = 1;
            Tourist testTourist = new Tourist()
            {
                Id = testId,
                Name = "Pepe",
                LastName = "Lopez",
                Email = "pepelopez@gmail.com",
                Bookings = null,
            };
            List<Tourist> touristList = new List<Tourist>()
            {

                new Tourist()
                {
                    Id=2,
                    Name="Pepe",
                    LastName="Lopez",
                    Email="pepelopez@gmail.com",
                    Bookings=null,
                },
            };

            touristList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristRepository(_context);
            var result = repository.GetByEmail("Hil");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetByEmail()
        {
            int testId = 1;
            Tourist testTourist = new Tourist()
            {
                Id = testId,
                Name = "Pepe",
                LastName = "Lopez",
                Email = "pepelopez@gmail.com",
                Bookings = null,
            };
            List<Tourist> touristList = new List<Tourist>()
            {

                new Tourist()
                {
                    Id=2,
                    Name="Pepe",
                    LastName="Lopez",
                    Email="pepeooolopez@gmail.com",
                    Bookings=null,
                },testTourist
            };

            touristList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristRepository(_context);
            var result = repository.GetByEmail("pepelopez@gmail.com");
            Assert.IsTrue(testTourist.Equals(result));
        }
    }
}
