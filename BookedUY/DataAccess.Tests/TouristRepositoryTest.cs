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
    }
}
