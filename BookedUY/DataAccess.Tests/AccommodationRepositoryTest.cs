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
    public class AccommodationRepositoryTest
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
        public void GetAllAccommodationsTest()
        {
            List<Accommodation> accommodationsToReturn = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id=1,
                    Address="Test",
                    Bookings=null,
                    ContactNumber="09934566",
                    Full= false,
                    Name="Radisson",
                    Information="nice",
                    PricePerNight=1.76,
                    Spot=null,
                    SpotId=1
                },
                new Accommodation()
                {
                    Id=2,
                    Address="Test1",
                    Bookings=null,
                    ContactNumber="0993456611",
                    Full= false,
                    Name="Hilton",
                    Information="Epic",
                    PricePerNight=120.76,
                    Spot=null,
                    SpotId=2
                },
            };
            
            accommodationsToReturn.ForEach(a => _context.Add(a));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(accommodationsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddAccommodation()
        {
            int id = 3;
            Accommodation accommodation = new Accommodation()
            {
                Id = id,
                Address = "Test",
                Bookings = null,
                ContactNumber = "09934566",
                Full = false,
                Name = "Radisson",
                Information = "nice",
                PricePerNight = 1.76,
                Spot = null,
                SpotId = 1
            };
            var repository = new AccommodationRepository(_context);
            repository.Add(accommodation);

            Assert.AreEqual(_context.Find<Accommodation>(id), accommodation);
        }

        [TestMethod]
        public void GetDeleteAccommodationsTest()
        {
            int id = 1;
            Accommodation accommodation = new Accommodation()
            {
                Id = id,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = null,
                SpotId = 2
            };
            _context.Add(accommodation);
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);

            repository.Delete(accommodation);

            Assert.IsNull(_context.Find<Accommodation>(id));
        }
    }
}
