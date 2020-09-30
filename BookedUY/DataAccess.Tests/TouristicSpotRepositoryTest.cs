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
            var options = new DbContextOptionsBuilder<BookedUYContext>()
                .UseInMemoryDatabase(databaseName: "BookedUYDB").Options;
            var context = new BookedUYContext(options);
            spotsToReturn.ForEach(s => context.Add(s));
            context.SaveChanges();
            var repository = new TouristicSpotRepository(context);
            var result = repository.GetAll();
            Assert.IsTrue(spotsToReturn.SequenceEqual(result));
        }
    }
}
