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
        [TestMethod]
        public void TestGetAllSpotsOk()
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
            var options = new DbContextOptionsBuilder<BookedUYContext>()
                .UseInMemoryDatabase(databaseName: "BookedUYDB").Options;
            var context = new BookedUYContext(options);
            touristsToReturn.ForEach(s => context.Add(s));
            context.SaveChanges();
            var repository = new TouristRepository(context);
            var result = repository.GetAll();
            Assert.IsTrue(touristsToReturn.SequenceEqual(result));
        }
    }
}
