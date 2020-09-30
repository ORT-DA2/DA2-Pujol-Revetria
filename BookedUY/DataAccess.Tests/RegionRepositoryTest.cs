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
            var options = new DbContextOptionsBuilder<BookedUYContext>()
                .UseInMemoryDatabase(databaseName: "BookedUYDB").Options;
            var context = new BookedUYContext(options);
            regionsToReturn.ForEach(r => context.Add(r));
            context.SaveChanges();
            var repository = new RegionRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(regionsToReturn.SequenceEqual(result));
        }
    }
}
