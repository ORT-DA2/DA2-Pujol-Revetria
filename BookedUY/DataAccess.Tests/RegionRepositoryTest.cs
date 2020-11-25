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

        [TestMethod]
        public void TestAdd()
        {
            Region region = new Region()
            {
                Id = 1,
                Name = "Region Pajaros Pintados",
                Spots = null
            };
            var repository = new RegionRepository(_context);

            repository.AddAndSave(region);

            Assert.AreEqual(repository.GetById(region.Id), region);
        }

        [TestMethod]
        public void TestDelete()
        {
            Region region = new Region()
            {
                Id = 1,
                Name = "Region Pajaros Pintados",
                Spots = null
            };

            _context.Add(region);
            _context.SaveChanges();
            var repository = new RegionRepository(_context);

            repository.Delete(region);

            Assert.IsNull(repository.GetById(region.Id));
        }

        [TestMethod]
        public void TestGetById()
        {
            Region region = new Region()
            {
                Id = 1,
                Name = "Region Pajaros Pintados",
                Spots = null
            };
            _context.Add(region);
            _context.SaveChanges();
            var repository = new RegionRepository(_context);

            var result = repository.GetById(region.Id);

            Assert.AreEqual(result, region);
        }

        [TestMethod]
        public void TestGetByIdNull()
        {
            Region region = new Region()
            {
                Id = 1,
                Name = "Region Pajaros Pintados",
                Spots = null
            };

            _context.Add(region);
            _context.SaveChanges();
            var repository = new RegionRepository(_context);

            var result = repository.GetById(2);

            Assert.IsNull(result);
        }
    }
}