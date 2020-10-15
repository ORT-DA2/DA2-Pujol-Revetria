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
                    Spot=new TouristicSpot(){
                        Name = "a"
                    },
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
                    Spot=new TouristicSpot(){
                        Name = "h"
                    },
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
            int testId = 5;
            List<CategoryTouristicSpot> categories = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot category = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 5
            };
            categories.Add(category);
            TouristicSpot spot = new TouristicSpot()
            {
                Name = "h",
                Categories = categories,
                RegionId = testId
            };
            this._context.TouristicSpots.Add(spot);
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
                Spot = spot,
                SpotId = 1
            };
            var repository = new AccommodationRepository(_context);
            repository.Add(accommodation);

            Assert.AreEqual(_context.Find<Accommodation>(id), accommodation);
        }

        [TestMethod]
        public void DeleteAccommodationsTest()
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
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            _context.Add(accommodation);
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);

            repository.Delete(accommodation);

            Assert.IsNull(_context.Find<Accommodation>(id));
        }

        [TestMethod]
        public void TestGetByIdAccomodation()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id = 2,
                    Address = "Test",
                    Bookings = null,
                    ContactNumber = "09934566",
                    Full = false,
                    Name = "Radisson",
                    Information = "nice",
                    PricePerNight = 1.76,
                    Spot=new TouristicSpot(){
                        Name = "a"
                    },
                    SpotId = 1
                },
            };
            accommodationList.Add(testAccommodation);
            accommodationList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);

            var result = repository.GetById(testId);

            Assert.AreEqual(testAccommodation, result);
        }

        [TestMethod]
        public void TestGetByNameNull()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "a"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id = 2,
                    Address = "Test",
                    Bookings = null,
                    ContactNumber = "09934566",
                    Full = false,
                    Name = "Radisson",
                    Information = "nice",
                    PricePerNight = 1.76,
                    Spot=new TouristicSpot(){
                        Name = "h"
                    },
                    SpotId = 1
                },testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            var result = repository.GetByName("Hil");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetByName()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id = 2,
                    Address = "Test",
                    Bookings = null,
                    ContactNumber = "09934566",
                    Full = false,
                    Name = "Radisson",
                    Information = "nice",
                    PricePerNight = 1.76,
                    Spot=new TouristicSpot(){
                        Name = "a"
                    },
                    SpotId = 1
                },testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            var result = repository.GetByName("Hilton");
            Assert.IsTrue(testAccommodation.Equals(result));
        }

        [TestMethod]
        public void TestGetAvailableBySpot()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "a"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id = 2,
                    Address = "Test",
                    Bookings = null,
                    ContactNumber = "09934566",
                    Full = false,
                    Name = "Radisson",
                    Information = "nice",
                    PricePerNight = 1.76,
                    Spot=new TouristicSpot(){
                        Name = "h"
                    },
                    SpotId = 1
                },testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            var result = repository.GetAvailableBySpot(2);
            Assert.IsTrue(testAccommodation.Equals(result.FirstOrDefault()));
        }

        [TestMethod]
        public void TestGetAvailableBySpotNull()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                new Accommodation()
                {
                    Id = 2,
                    Address = "Test",
                    Bookings = null,
                    ContactNumber = "09934566",
                    Full = false,
                    Name = "Radisson",
                    Information = "nice",
                    PricePerNight = 1.76,
                    Spot=new TouristicSpot(){
                        Name = "a"
                    },
                    SpotId = 1
                },testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            var result = repository.GetAvailableBySpot(3);
            Assert.IsNull(result.FirstOrDefault());
        }

        [TestMethod]
        public void TestUpdateCapacityTrue()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            repository.UpdateCapacity(1, true);
            Assert.IsTrue(_context.Accommodations.Find(1).Full);
        }

        [TestMethod]
        public void TestUpdateCapacityFalse()
        {
            int testId = 1;
            Accommodation testAccommodation = new Accommodation()
            {
                Id = testId,
                Address = "Test1",
                Bookings = null,
                ContactNumber = "0993456611",
                Full = false,
                Name = "Hilton",
                Information = "Epic",
                PricePerNight = 120.76,
                Spot = new TouristicSpot()
                {
                    Name = "h"
                },
                SpotId = 2
            };
            List<Accommodation> accommodationList = new List<Accommodation>()
            {
                testAccommodation,
            };

            accommodationList.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new AccommodationRepository(_context);
            repository.UpdateCapacity(1, false);
            Assert.IsFalse(_context.Accommodations.Find(1).Full);
        }
    }
}