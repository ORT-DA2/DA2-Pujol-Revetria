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
                    Id = 1,
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

            Assert.IsTrue(bookingsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddBooking()
        {
            List<AccommodationImage> list = new List<AccommodationImage>();
            AccommodationImage image = new AccommodationImage()
            {
                AccommodationId = 1,
                Image = "a"
            };
            list.Add(image);
            Accommodation accommodation = new Accommodation()
            {
                Id = 1,
                Name = "a",
                Address = "d",
                ContactNumber = "a",
                Images = list
            };
            this._context.Accommodations.Add(accommodation);
            Booking booking = new Booking()
            {
                Id = 1,
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
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                LastName = "a",
                Name = "a"
            };
            booking.HeadGuest = tourist;
            var repository = new BookingRepository(_context);

            repository.Add(booking);

            Assert.AreEqual(_context.Find<Booking>(1), booking);
        }

        [TestMethod]
        public void TestGetByIdBooking()
        {
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

            var result = repository.GetById(1);

            Assert.AreEqual(testBooking, result);
        }

        [TestMethod]
        public void TestDelete()
        {
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

        [TestMethod]
        public void TestGetReport()
        {
            Booking testBooking = new Booking()
            {
                Id = 1,
                Accommodation = new Accommodation()
                {
                    Name = "a",
                    SpotId = 1
                },
                AccommodationId = 1,
                BookingHistory = new List<BookingStage>(),
                CheckIn = new DateTime(2020, 12, 14),
                CheckOut = new DateTime(2020, 12, 15),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "a@a.com"
                },
                TotalPrice = 35
            };
            BookingStage bookingStageForBooking1 = new BookingStage()
            {
                AdministratorId = 1,
                AsociatedBookingId = 1,
                Description = "A",
                EntryDate = new DateTime(2020, 12, 22),
                Status = Status.Received,
            };
            testBooking.BookingHistory.Add(bookingStageForBooking1);
            Booking booking = new Booking()
            {
                Id = 2,
                Accommodation = new Accommodation()
                {
                    Name = "b",
                    SpotId = 1
                },
                AccommodationId = 1,
                BookingHistory = new List<BookingStage>(),
                CheckIn = new DateTime(2020, 12, 14),
                CheckOut = new DateTime(2020, 12, 15),
                GuestId = 6,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "b@b.com"
                },
                TotalPrice = 142
            };
            BookingStage bookingStageForBooking2 = new BookingStage()
            {
                AdministratorId = 1,
                AsociatedBookingId = 2,
                Description = "A",
                EntryDate = new DateTime(2020, 12, 22),
                Status = Status.Received,
            };
            booking.BookingHistory.Add(bookingStageForBooking2);
            List<Booking> bookingsList = new List<Booking>
            {
                testBooking,
                booking
            };
            List<ReportTuple> expected = new List<ReportTuple>()
            {
                new ReportTuple()
                {
                    Id = 1,
                    Count = 1
                },
                new ReportTuple()
                {
                    Id = 2,
                    Count = 1
                }
            };
            bookingsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingRepository(_context);
            DateTime start = new DateTime(2020, 12, 12);
            DateTime end = new DateTime(2020, 12, 24);

            var result = repository.GetReport(1, start, end);

            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}