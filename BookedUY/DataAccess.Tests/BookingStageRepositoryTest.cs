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
                    Administrator = null,
                    AdministratorId=0,
                    AsociatedBooking=null,
                    AsociatedBookingId=0,
                    EntryDate= DateTime.Now,
                    Status = new Status(),
                },
                new BookingStage()
                {
                    Id=2,
                    Description = "The booking was rejected due to payment issues, please contact your bank",
                    Administrator = null,
                    AdministratorId = 0,
                    AsociatedBooking = null,
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
        public void TestAddBookingStage()
        {
            int id = 3;
            BookingStage bookingStage = new BookingStage()
            {
                Id = id,
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
            Assert.AreEqual(_context.Find<BookingStage>(id), bookingStage);

        }
    }
}
