using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Tests
{
    [TestClass]
    public class RegionRepositoryTest
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
        public void TestGetAllRegionsOk()
        {
            List<Region> regionsToReturn = new List<Region>()
            {
                new Region()
                {
                    Id=1,
                    Name="Region Pajaros Pintados",
                    Spots = null
                },
                new Region()
                {
                    Id=2,
                    Name="Region Metropolitana",
                    Spots = null
                },
            };

            regionsToReturn.ForEach(r => _context.Add(r));
            _context.SaveChanges();
            var repository = new RegionRepository(_context);

            var result = repository.GetAll();

            Assert.IsTrue(regionsToReturn.SequenceEqual(result));
        }
    }
}
