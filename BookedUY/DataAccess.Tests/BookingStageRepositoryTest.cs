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
    public class BookingStageRepositoryTest
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
        public void TestGetAllBookingStagesOk()
        {
            List<BookingStage> bookingStagesToReturn = new List<BookingStage>()
            {
                new BookingStage()
                {
                    Id=1,
                    Description="The booking was added correctly, awaiting payment",
                    Administrator = new Administrator(){
                    Email="b@b.com"
                    },
                    AdministratorId=0,
                    AsociatedBooking= new Booking(),
                    AsociatedBookingId=0,
                    EntryDate= DateTime.Now,
                    Status = new Status(),
                },
                new BookingStage()
                {
                    Id=2,
                    Description = "The booking was rejected due to payment issues, please contact your bank",
                    Administrator = new Administrator(){
                        Email="a@a.com"
                    },
                    AdministratorId = 0,
                    AsociatedBooking = new Booking(),
                    AsociatedBookingId = 0,
                    EntryDate = DateTime.Now,
                    Status = new Status(),
                },
            };
            bookingStagesToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(bookingStagesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetAllBookingStagesNull()
        {
            List<BookingStage> bookingStagesToReturn = new List<BookingStage>();
            bookingStagesToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void TestAddBookingStage()
        {
            BookingStage bookingStage = new BookingStage()
            {
                Id = 3,
                Description = "Tayment",
                Administrator = null,
                AdministratorId = 0,
                AsociatedBooking = null,
                AsociatedBookingId = 0,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            var repository = new BookingStageRepository(_context);

            repository.Add(bookingStage);

            Assert.AreEqual(_context.Find<BookingStage>(3), bookingStage);
        }

        [TestMethod]
        public void TestGetBookingStageByBookingOk()
        {
            BookingStage bookingStage1 = new BookingStage()
            {
                Id = 1,
                Description = "The booking was added correctly, awaiting payment",
                Administrator = new Administrator()
                {
                    Email = "a@a.com"
                },
                AdministratorId = 0,
                AsociatedBooking = new Booking(),
                AsociatedBookingId = 1,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            BookingStage bookingStage3 = new BookingStage()
            {
                Id = 3,
                Description = "Theaiting payment",
                Administrator = new Administrator()
                {
                    Email = "b@b.com"
                },
                AdministratorId = 0,
                AsociatedBooking = bookingStage1.AsociatedBooking,
                AsociatedBookingId = 1,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            List<BookingStage> bookingStages = new List<BookingStage>()
            {
                bookingStage1,
                bookingStage3,
                new BookingStage()
                {
                    Id=2,
                    Description = "The booking was rejected due to payment issues, please contact your bank",
                    Administrator = new Administrator(){
                        Email="c@c.com"
                    },
                    AdministratorId = 0,
                    AsociatedBooking = new Booking(),
                    AsociatedBookingId = 2,
                    EntryDate = DateTime.Now,
                    Status = new Status(),
                },
            };
            List<BookingStage> listToReturn = new List<BookingStage>
            {
                bookingStage1,
                bookingStage3
            };
            bookingStages.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            var result = repository.GetByBooking(1);

            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetBookingStageByBookingNull()
        {
            BookingStage bookingStage1 = new BookingStage()
            {
                Id = 1,
                Description = "The booking was added correctly, awaiting payment",
                Administrator = new Administrator()
                {
                    Email = "a@a.com"
                },
                AdministratorId = 0,
                AsociatedBooking = null,
                AsociatedBookingId = 1,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            BookingStage bookingStage3 = new BookingStage()
            {
                Id = 3,
                Description = "Theaiting payment",
                Administrator = new Administrator()
                {
                    Email = "b@b.com"
                },
                AdministratorId = 0,
                AsociatedBooking = null,
                AsociatedBookingId = 1,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            List<BookingStage> bookingStages = new List<BookingStage>()
            {
                bookingStage1,
                bookingStage3,
                new BookingStage()
                {
                    Id=2,
                    Description = "The booking was rejected due to payment issues, please contact your bank",
                    Administrator = new Administrator(){
                        Email="c@c.com"
                    },
                    AdministratorId = 0,
                    AsociatedBooking = null,
                    AsociatedBookingId = 2,
                    EntryDate = DateTime.Now,
                    Status = new Status(),
                },
            };
            List<BookingStage> listToReturn = new List<BookingStage>
            {
                bookingStage1,
                bookingStage3
            };
            bookingStages.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            var result = repository.GetByBooking(3);
            
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void DeleteBookingStageTest()
        {
            BookingStage bookingStage = new BookingStage()
            {
                Id = 1,
                Description = "The booking was rejected due to payment issues, please contact your bank",
                Administrator = new Administrator()
                {
                    Email = "a@a.com"
                },
                AdministratorId = 0,
                AsociatedBooking = null,
                AsociatedBookingId = 2,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            _context.Add(bookingStage);
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            repository.Delete(bookingStage);

            Assert.IsNull(_context.Find<BookingStage>(1));
        }

        [TestMethod]
        public void TestGetByIdBookingStage()
        {
            BookingStage testBookingStage = new BookingStage()
            {
                Id = 1,
                Description = "The booking was rejected due to payment issues, please contact your bank",
                Administrator = new Administrator()
                {
                    Email = "a@a.com"
                },
                AdministratorId = 0,
                AsociatedBooking = new Booking(),
                AsociatedBookingId = 1,
                EntryDate = DateTime.Now,
                Status = new Status(),
            };
            _context.Add(testBookingStage);
            _context.SaveChanges();
            var repository = new BookingStageRepository(_context);

            var result = repository.GetById(1);

            Assert.AreEqual(testBookingStage, result);
        }
    }
}