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
    public class BookingRepositoryTest
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
        public void TestGetAllBookingsOk()
        {
            List<Booking> bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id=1,
                    Accommodation = new Accommodation(){
                        Name="b"
                    },
                    AccommodationId = 1,
                    BookingHistory = new List<BookingStage>(),
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(3),
                    GuestId = 2,
                    Guests = new List<Guest>(),
                    HeadGuest = new Tourist(){
                        Email="a@a.com"
                    },
                    TotalPrice = 35
                },
                new Booking()
                {
                    Id=2,
                    Accommodation = new Accommodation(){
                        Name="a"},
                    AccommodationId = 1,
                    BookingHistory = new List<BookingStage>(),
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(7),
                    GuestId = 6,
                    Guests = new List<Guest>(),
                    HeadGuest = new Tourist(){
                        Email="b@b.com"
                    },
                    TotalPrice = 142
                },
            };

            bookingsToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingRepository(_context);

            var result = repository.GetAll();
            Console.WriteLine(result.Count());
            Assert.IsTrue(bookingsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddBooking()
        {
            int id = 1;
            Booking booking = new Booking()
            {
                Id = id,
                Accommodation = null,
                AccommodationId = 1,
                BookingHistory = null,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(7),
                GuestId = 6,
                Guests = new List<Guest>(),
                HeadGuest = null,
                TotalPrice = 142
            };

            var repository = new BookingRepository(_context);
            repository.Add(booking);
            Assert.AreEqual(_context.Find<Booking>(id), booking);
        }

        [TestMethod]
        public void TestGetByIdBooking()
        {
            int testId = 1;
            Booking testBooking = new Booking()
            {
                Id = 1,
                Accommodation = new Accommodation()
                {
                    Name = "a"
                },
                AccommodationId = 1,
                BookingHistory = new List<BookingStage>(),
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "a@a.com"
                },
                TotalPrice = 35
            };
            List<Booking> bookingsList = new List<Booking>()
            {
                new Booking()
                {
                    Id=2,
                    Accommodation = new Accommodation()
                    {
                        Name="b"
                    },
                    AccommodationId = 1,
                    BookingHistory = new List<BookingStage>(),
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(7),
                    GuestId = 6,
                    Guests = new List<Guest>(),
                    HeadGuest = new Tourist()
                    {
                        Email = "b@b.com"
                    },
                    TotalPrice = 142
                },
            };
            bookingsList.Add(testBooking);
            bookingsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingRepository(_context);

            var result = repository.GetById(testId);

            Assert.AreEqual(testBooking, result);
        }

        [TestMethod]
        public void TestDelete()
        {
            int testId = 1;
            Booking testBooking = new Booking()
            {
                Id = 1,
                Accommodation = null,
                AccommodationId = 1,
                BookingHistory = null,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = null,
                TotalPrice = 35
            };
            List<Booking> bookingsList = new List<Booking>()
            {
                new Booking()
                {
                    Id=2,
                    Accommodation = null,
                    AccommodationId = 1,
                    BookingHistory = null,
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(7),
                    GuestId = 6,
                    Guests = new List<Guest>(),
                    HeadGuest = null,
                    TotalPrice = 142
                },
            };
            bookingsList.Add(testBooking);
            bookingsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingRepository(_context);

            repository.Delete(testBooking);

            Assert.IsNull(_context.Bookings.Find(1));
        }
    }
}