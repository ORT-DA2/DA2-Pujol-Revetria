using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace WebApi.Tests
{
    [TestClass]
    public class BookingControllerTest
    {
        [TestMethod]
        public void TestGetAllBookingsOK()
        {
            List<Booking> BookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id=1,
                    Accommodation = new Accommodation(),
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                    
                }
            };
        }
    }
}
