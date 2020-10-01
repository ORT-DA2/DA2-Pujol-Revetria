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
    public class TouristicSpotRepositoryTest
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
        public void TestGetAllSpotsOk()
        {
            List<TouristicSpot> spotsToReturn = new List<TouristicSpot>()
            {
                new TouristicSpot()
                {
                    Id=1,
                    Name="Villa Serrana",
                    Accommodations=null,
                    Description="Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                    " a 25 kilómetros al noreste de la capital departamental," +
                    " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
                    Region=null,
                    RegionId=2,
                    Categories=null,
                },
                new TouristicSpot()
                {
                    Id=2,
                    Name="Colonia del Sacramento",
                    Accommodations=null,
                    Description="Es conocida por su Barrio Histórico con calles de" +
                    " adoquines rodeadas de edificios que datan de la" +
                    " época en que era un asentamiento portugués.",
                    Region=null,
                    RegionId=1,
                    Categories=null,
                },
            };

            spotsToReturn.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetAll();
            Assert.IsTrue(spotsToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddSpot()
        {
            int id = 1;
            TouristicSpot spot = new TouristicSpot()
            {
                Id = id,
                Name = "Colonia del Sacramento",
                Accommodations = null,
                Description = "Es conocida por su Barrio Histórico con calles de" +
                    " adoquines rodeadas de edificios que datan de la" +
                    " época en que era un asentamiento portugués.",
                Region = null,
                RegionId = 1,
                Categories = null,
            };
            var repository = new TouristicSpotRepository(_context);
            repository.Add(spot);

            Assert.AreEqual(_context.Find<TouristicSpot>(id), spot);
        }
    }
}
