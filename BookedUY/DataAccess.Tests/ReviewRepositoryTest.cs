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
                    Comment="Horrible",
                    Score=3,
                    BookingId = 2
                },
                new Review()
                {
                    Id=2,
                    Comment="Bueni",
                    BookingId = 1,
                    Score=5
                },
            };
            _context.Add(new Accommodation()
            {
                Name = "b",
                Id = 1
            });
            _context.Add(new Booking
            {
                Id = 1,
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
                AccommodationId = 1,
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

            Assert.IsTrue(reviewsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddReview()
        {
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
                Id = 1,
                BookingId = 1,
                Comment = "Bueni",
                Score = 5
            };
            var repository = new ReviewRepository(_context);

            repository.Add(review);

            Assert.AreEqual(_context.Find<Review>(1), review);
        }

        [TestMethod]
        public void TestGetByIdReview()
        {
            Review testReview = new Review()
            {
                Id = 1,
                Comment = "Bueni",
                Score = 5
            };
            List<Review> reviewsList = new List<Review>()
            {
                new Review()
                {
                    Id=5,
                    Comment="Bueni",
                    Score=5
                },
            };
            reviewsList.Add(testReview);
            reviewsList.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new ReviewRepository(_context);

            var result = repository.GetById(1);

            Assert.AreEqual(testReview, result);
        }

        [TestMethod]
        public void TestDelete()
        {
            Review testReview = new Review()
            {
                Id = 2,
                Comment = "Bueni",
                Score = 5
            };
            List<Review> reviewsList = new List<Review>()
            {
                new Review()
                {
                    Id = 4,
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


        [TestMethod]
        public void TestGetReviewByAccommodationOk()
        {
            Review review1 = new Review()
            {
                Id = 1,
                Comment = "Prueba1",
                Score = 3,
                BookingId = 1
            };
            Review review2 = new Review()
            {
                Id = 3,
                Comment = "Prueba12",
                Score = 4,
                BookingId = 2
            };
            List<Review> reviews = new List<Review>()
            {
                review1,
                review2
            };
            _context.Add(
                new Accommodation()
                {
                    Id = 1,
                    Name = "a"
                }
            );
            _context.Add(
                new Accommodation()
                {
                    Id = 2,
                    Name = "b"
                }
            );
            _context.Add(new Booking
            {
                Id = 1,
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
                AccommodationId = 1,
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
            _context.Add(new Booking
            {
                Id = 3,
                AccommodationId = 2,
                BookingHistory = new List<BookingStage>(),
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                GuestId = 2,
                Guests = new List<Guest>(),
                HeadGuest = new Tourist()
                {
                    Email = "c@c.com"
                },
                TotalPrice = 35
            });
            _context.Add(new Review()
            {
                Id = 2,
                Comment = "Prueba123",
                Score = 1,
                BookingId = 3
            });
            reviews.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new ReviewRepository(_context);

            var result = repository.GetByAccommodation(1);

            Assert.IsTrue(reviews.SequenceEqual(result));
        }
    }
}

