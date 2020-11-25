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
                    Accommodations=new List<Accommodation>(),
                    Description="Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                    " a 25 kilómetros al noreste de la capital departamental," +
                    " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
                    Region=new Region(),
                    RegionId=1,
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
                    Region=new Region(),
                    RegionId=2,
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
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
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

            repository.AddAndSave(spot);

            Assert.AreEqual(_context.Find<TouristicSpot>(1), spot);
        }

        [TestMethod]
        public void TestGetByRegion()
        {
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = new List<Accommodation>(),
                Description = "Es conocida por su Barrio Histórico con calles de" +
                " adoquines rodeadas de edificios que datan de la" +
                " época en que era un asentamiento portugués.",
                Region = new Region(),
                RegionId = 1,
                Categories = new List<CategoryTouristicSpot>(),
            };
            List<TouristicSpot> spotsToReturn = new List<TouristicSpot>()
            {
                new TouristicSpot()
                {
                    Id=1,
                    Name="Villa Serrana",
                    Accommodations=new List<Accommodation>(),
                    Description="Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                    " a 25 kilómetros al noreste de la capital departamental," +
                    " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
                    Region=new Region(){Id=3 },
                    RegionId=3,
                    Categories=new List<CategoryTouristicSpot>(),
                },touristicSpot,
            };
            List<TouristicSpot> listToReturn = new List<TouristicSpot>
            {
                touristicSpot
            };
            spotsToReturn.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetByRegion(1);

            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByCategory()
        {
            List<int> listOfCategoriesToSearch = new List<int>
            {
                1,
                3
            };
            CategoryTouristicSpot category1TouristicSpot4 = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 4
            };
            CategoryTouristicSpot category2TouristicSpot1 = new CategoryTouristicSpot()
            {
                CategoryId = 2,
                TouristicSpotId = 1
            };
            CategoryTouristicSpot category3TouristicSpot4 = new CategoryTouristicSpot()
            {
                CategoryId = 3,
                TouristicSpotId = 4
            };
            List<CategoryTouristicSpot> listOfCategoiresOfTouristicSpot4 = new List<CategoryTouristicSpot>
            {
                category1TouristicSpot4,
                category3TouristicSpot4
            };
            List<CategoryTouristicSpot> listOfCategoriesOfTouristicSpot1 = new List<CategoryTouristicSpot>
            {
                category2TouristicSpot1
            };
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = new List<Accommodation>(),
                Description = "Es conocida por su Barrio Histórico con calles de",
                Region = new Region(),
                RegionId = 0,
                Categories = listOfCategoiresOfTouristicSpot4,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                new TouristicSpot()
                {
                    Id=1,
                    Name="Villa Serrana",
                    Accommodations=new List<Accommodation>(),
                    Description="Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                    Region=new Region(),
                    RegionId=0,
                    Categories=listOfCategoriesOfTouristicSpot1,
                },touristicSpot,
            };
            List<TouristicSpot> listToReturn = new List<TouristicSpot>
            {
                touristicSpot
            };
            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            var result = repository.GetByCategory(listOfCategoriesToSearch);
            
            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByCategoryAndByRegion()
        {
            List<int> listOfCategoriesToSearch = new List<int>
            {
                1,
                3
            };
            CategoryTouristicSpot category1TouristicSpot4 = new CategoryTouristicSpot()
            {
                CategoryId = 1,
                TouristicSpotId = 4
            };
            CategoryTouristicSpot category2TouristicSpot1 = new CategoryTouristicSpot()
            {
                CategoryId = 2,
                TouristicSpotId = 1
            };
            CategoryTouristicSpot category3TouristicSpot4 = new CategoryTouristicSpot()
            {
                CategoryId = 3,
                TouristicSpotId = 4
            };
            List<CategoryTouristicSpot> listOfCategoiresOfTouristicSpot4 = new List<CategoryTouristicSpot>
            {
                category1TouristicSpot4,
                category3TouristicSpot4
            };
            List<CategoryTouristicSpot> listOfCategoriesOfTouristicSpot1 = new List<CategoryTouristicSpot>
            {
                category2TouristicSpot1
            };
            TouristicSpot touristicSpotToReturn = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = new List<Accommodation>(),
                Description = "Es conocida por su Barrio Histórico con calles de",
                Region = new Region() { Id = 2 },
                RegionId = 2,
                Categories = listOfCategoiresOfTouristicSpot4,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                new TouristicSpot()
                {
                    Id=1,
                    Name="Villa Serrana",
                    Accommodations=new List<Accommodation>(),
                    Description="Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                    Region=new Region(),
                    RegionId=1,
                    Categories=listOfCategoriesOfTouristicSpot1,
                },
                touristicSpotToReturn,
                new TouristicSpot()
                {
                    Id=3,
                    Name="Vierrana",
                    Accommodations=new List<Accommodation>(),
                    Description="Vilartamento de Lavalleja de Uruguay," +
                    " a 25 kilómetros",
                    Region=touristicSpotToReturn.Region,
                    RegionId=2,
                    Categories=listOfCategoriesOfTouristicSpot1,
                },
            };
            List<TouristicSpot> listToReturn = new List<TouristicSpot>
            {
                touristicSpotToReturn
            };
            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            var result = repository.GetByCategoryAndRegion(listOfCategoriesToSearch, 2);

            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByID()
        {
            TouristicSpot touristicSpotToReturn = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = new List<Accommodation>(),
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            List<TouristicSpot> touristicSpots = new List<TouristicSpot>()
            {
                touristicSpotToReturn,
                new TouristicSpot()
                {
                    Id=2,
                    Name="Colonia del Sacramento",
                    Accommodations=new List<Accommodation>(),
                    Description="Es conocida por su Barrio Histórico con calles de",
                    Region=null,
                    RegionId=1,
                    Categories=null,
                },
            };
            touristicSpots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            var result = repository.GetById(1);

            Assert.IsTrue(touristicSpotToReturn.Equals(result));
        }

        [TestMethod]
        public void TestDelete()
        {
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            _context.Add(touristicSpot);
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            repository.Delete(touristicSpot);

            Assert.IsNull(_context.Find<TouristicSpot>(touristicSpot.Id));
        }

        [TestMethod]
        public void TestGetByNameNull()
        {
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                spot,
                new TouristicSpot()
                {
                    Id=2,
                    Name="Colonia del Sacramento",
                    Accommodations=null,
                    Description="Es conocida por su Barrio Histórico con calles de",
                    Region=null,
                    RegionId=1,
                    Categories=null,
                },
            };
            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            var result = repository.GetByName("Via");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetByName()
        {
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay,",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                spot,
                new TouristicSpot()
                {
                    Id=2,
                    Name="Colonia del Sacramento",
                    Accommodations=null,
                    Description="Es conocida por su Barrio Histórico con calles de",
                    Region=null,
                    RegionId=1,
                    Categories=null,
                },
            };

            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            var result = repository.GetByName("Villa Serrana");

            Assert.IsTrue(spot.Equals(result));
        }
    }
}