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
    public class ReviewRepositoryTest
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
        public void TestGetAllReviewsOk()
        {
            List<Review> reviewsToReturn = new List<Review>()
            {
                new Review()
                {
                    Id=1,
                    Booking=null,
                    BookingId=1,
                    Comment="Horrible",
                    Score=3
                },
                new Review()
                {
                    Id=2,
                    Booking=null,
                    BookingId=2,
                    Comment="Bueni",
                    Score=5
                },
            };
            _context.Add(new Booking
            {
                Id = 1,
                Accommodation = new Accommodation()
                {
                    Name = "b"
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
            });
            _context.Add(new Booking
            {
                Id = 2,
                Accommodation = new Accommodation()
                {
                    Name = "a"
                },
                AccommodationId = 2,
                BookingHistory = new List<BookingStage>(),
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "b@b.com"
                },
                TotalPrice = 35
            });
            reviewsToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new ReviewRepository(_context);
            var result = repository.GetAll();
            Console.WriteLine(result.Count());
            Assert.IsTrue(reviewsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddReview()
        {
            int id = 1;
            Booking booking = new Booking()
            {
                Id = 1,
                Accommodation = new Accommodation()
                {
                    Name = "b"
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
            this._context.Bookings.Add(booking);
            Review review = new Review()
            {
                Id = id,
                Booking = null,
                BookingId = 1,
                Comment = "Bueni",
                Score = 5
            };
            var repository = new ReviewRepository(_context);
            repository.Add(review);
            Assert.AreEqual(_context.Find<Review>(id), review);
        }

        [TestMethod]
        public void TestGetByIdReview()
        {
            int testId = 1;
            Review testReview = new Review()
            {
                Id = testId,
                Booking = null,
                BookingId = 2,
                Comment = "Bueni",
                Score = 5
            };
            List<Review> reviewsList = new List<Review>()
            {
                new Review()
                {
                    Id=5,
                    Booking=null,
                    BookingId=3,
                    Comment="Bueni",
                    Score=5
                },
            };
            _context.Add(new Booking
            {
                Id = 3,
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
            });
            _context.Add(new Booking
            {
                Id = 2,
                Accommodation = new Accommodation()
                {
                    Name = "b"
                },
                AccommodationId = 2,
                BookingHistory = new List<BookingStage>(),
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "b@b.com"
                },
                TotalPrice = 35
            });
            reviewsList.Add(testReview);
            reviewsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new ReviewRepository(_context);

            var result = repository.GetById(testId);

            Assert.AreEqual(testReview, result);
        }

        [TestMethod]
        public void TestDelete()
        {
            Review testReview = new Review()
            {
                Id = 2,
                Booking = null,
                BookingId = 2,
                Comment = "Bueni",
                Score = 5
            };
            List<Review> reviewsList = new List<Review>()
            {
                new Review()
                {
                    Id = 4,
                    Booking = null,
                    BookingId = 12,
                    Comment="Bueni",
                    Score = 4
                },
            };
            reviewsList.Add(testReview);
            reviewsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new ReviewRepository(_context);

            repository.Delete(testReview);

            Assert.IsNull(_context.Reviews.Find(1));
        }
    }
}

