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

        [TestMethod]
        public void TestGetByRegion()
        {

            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = null,
                Description = "Es conocida por su Barrio Histórico con calles de" +
                " adoquines rodeadas de edificios que datan de la" +
                " época en que era un asentamiento portugués.",
                Region = null,
                RegionId = 1,
                Categories = null,
            };
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
                },touristicSpot,
            };

            spotsToReturn.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetByRegion(1);
            List<TouristicSpot> list = new List<TouristicSpot>();
            list.Add(touristicSpot);
            Assert.IsTrue(list.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByCategory()
        {
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(4);

            List<CategoryTouristicSpot> listCat1 = new List<CategoryTouristicSpot>();
            List<CategoryTouristicSpot> listCat2 = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot cat1 = new CategoryTouristicSpot();
            cat1.CategoryId = 1;
            CategoryTouristicSpot cat2 = new CategoryTouristicSpot();
            cat2.CategoryId = 2;
            CategoryTouristicSpot cat3 = new CategoryTouristicSpot();
            cat3.CategoryId = 3;
            listCat1.Add(cat1);
            listCat1.Add(cat3);
            listCat2.Add(cat2);

            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = null,
                Description = "Es conocida por su Barrio Histórico con calles de" +
                " adoquines rodeadas de edificios que datan de la" +
                " época en que era un asentamiento portugués.",
                Region = null,
                RegionId = 0,
                Categories = listCat1,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
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
                    RegionId=0,
                    Categories=listCat2,
                },touristicSpot,
            };

            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetByCategory(list1);
            List<TouristicSpot> listToReturn = new List<TouristicSpot>();
            listToReturn.Add(touristicSpot);
            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByCategoryAndByRegion()
        {
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(4);

            List<CategoryTouristicSpot> listCat1 = new List<CategoryTouristicSpot>();
            List<CategoryTouristicSpot> listCat2 = new List<CategoryTouristicSpot>();
            CategoryTouristicSpot cat1 = new CategoryTouristicSpot();
            cat1.CategoryId = 1;
            CategoryTouristicSpot cat2 = new CategoryTouristicSpot();
            cat2.CategoryId = 2;
            CategoryTouristicSpot cat3 = new CategoryTouristicSpot();
            cat3.CategoryId = 3;
            listCat1.Add(cat1);
            listCat1.Add(cat3);
            listCat2.Add(cat2);

            TouristicSpot touristicSpotToReturn = new TouristicSpot()
            {
                Id = 4,
                Name = "Colonia del Sacramento",
                Accommodations = null,
                Description = "Es conocida por su Barrio Histórico con calles de" +
                " adoquines rodeadas de edificios que datan de la" +
                " época en que era un asentamiento portugués.",
                Region = null,
                RegionId = 2,
                Categories = listCat1,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
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
                    RegionId=1,
                    Categories=listCat1,
                },touristicSpotToReturn,

                new TouristicSpot()
                {
                    Id=3,
                    Name="Vierrana",
                    Accommodations=null,
                    Description="Vilartamento de Lavalleja de Uruguay," +
                    " a 25 kilómetros",
                    Region=null,
                    RegionId=2,
                    Categories=listCat2,
                },
            };

            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetByCategoryAndRegion(list1, 2);
            List<TouristicSpot> listToReturn = new List<TouristicSpot>();
            listToReturn.Add(touristicSpotToReturn);
            Assert.IsTrue(listToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetByID()
        {
            TouristicSpot spotToReturn = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                " a 25 kilómetros al noreste de la capital departamental," +
                " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                spotToReturn,
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

            spots.ForEach(s => _context.Add(s));
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);
            var result = repository.GetById(1);
            Assert.IsTrue(spotToReturn.Equals(result));
        }

        [TestMethod]
        public void TestDelete()
        {
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                " a 25 kilómetros al noreste de la capital departamental," +
                " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
                Region = null,
                RegionId = 2,
                Categories = null,
            };
            List<TouristicSpot> spots = new List<TouristicSpot>()
            {
                spot,
            };

            _context.Add(spot);
            _context.SaveChanges();
            var repository = new TouristicSpotRepository(_context);

            repository.Delete(spot);

            Assert.IsNull(_context.Find<TouristicSpot>(spot.Id));
        }

        [TestMethod]
        public void TestGetByNameNull()
        {
            int id = 1;
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                            " a 25 kilómetros al noreste de la capital departamental," +
                            " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
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
                    Description="Es conocida por su Barrio Histórico con calles de" +
                    " adoquines rodeadas de edificios que datan de la" +
                    " época en que era un asentamiento portugués.",
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
            int id = 1;
            TouristicSpot spot = new TouristicSpot()
            {
                Id = 1,
                Name = "Villa Serrana",
                Accommodations = null,
                Description = "Villa Serrana es un poblado ubicado en el departamento de Lavalleja de Uruguay," +
                            " a 25 kilómetros al noreste de la capital departamental," +
                            " Minas, entre los valles de los arroyos Penitente y Marmarajá.",
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
                    Description="Es conocida por su Barrio Histórico con calles de" +
                    " adoquines rodeadas de edificios que datan de la" +
                    " época en que era un asentamiento portugués.",
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
