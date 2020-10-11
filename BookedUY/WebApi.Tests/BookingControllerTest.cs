using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrations.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.DTOs;

namespace WebApi.Tests
{
    [TestClass]
    public class BookingControllerTest
    {
        [TestMethod]
        public void TestGetAllBookingsOK()
        {
            Tourist tou = new Tourist();
            tou.Email = "s@s.com";
            tou.Id = 1;
            tou.Name = "s";
            tou.LastName = "b";

            int testId = 5;
            Booking booking = new Booking();
            booking.Id = testId;
            booking.TotalPrice = 10;
            booking.CheckIn = DateTime.Now.AddDays(1);
            booking.CheckOut = DateTime.Now.AddDays(2);
            booking.HeadGuest = tou;
            List<Booking> list = new List<Booking>();
            list.Add(booking);
            var mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(list);
            var controller = new BookingController(mock.Object);
            var result = controller.Get() as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void TestGetByIdBookingsOK()
        {
            Tourist tou = new Tourist();
            tou.Email = "s@s.com";
            tou.Id = 1;
            tou.Name = "s";
            tou.LastName = "b";
            int testId = 5;
            Accommodation a = new Accommodation();
            a.Id = testId;
            a.Name = "a";
            a.Address = "a";
            a.ContactNumber = "2";
            Booking booking = new Booking();
            booking.Id = testId;
            booking.TotalPrice = 10;
            booking.CheckIn = DateTime.Now.AddDays(1);
            booking.CheckOut = DateTime.Now.AddDays(2);
            booking.HeadGuest = tou;
            booking.Accommodation = a;
            Guest g = new Guest();
            g.Amount = 1;
            g.Multiplier = 1;
            List<Guest> gList = new List<Guest>();
            gList.Add(g);
            gList.Add(g);
            gList.Add(g);
            booking.Guests = gList;
            var mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            mock.Setup(p => p.GetById(It.IsAny<int>())).Returns(booking);
            var controller = new BookingController(mock.Object);
            var result = controller.Get(5) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateAccommodationOK()
        {
            int testId = 5;
            Tourist tou = new Tourist();
            tou.Email = "s@s.com";
            tou.Id = 1;
            tou.Name = "s";
            tou.LastName = "b";
            Booking booking = new Booking();
            booking.Id = testId;
            booking.TotalPrice = 10;
            booking.CheckIn = DateTime.Now.AddDays(1);
            booking.CheckOut = DateTime.Now.AddDays(2);
            booking.HeadGuest = tou;
            BookingModelIn bookingModel = new BookingModelIn();
            bookingModel.CheckIn = booking.CheckIn;
            bookingModel.CheckOut = booking.CheckOut;
            bookingModel.GuestEmail = booking.HeadGuest.Email;
            bookingModel.GuestName = booking.HeadGuest.Name;
            bookingModel.GuestLastName = booking.HeadGuest.LastName;
            Guest g = new Guest();
            g.Amount = 1;
            g.Multiplier = 1;
            Guest[] gList = new Guest[3];
            gList[0]= g;
            gList[1] = g;
            gList[2] = g;
            bookingModel.Guests = gList;
            var mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            mock.Setup(p => p.AddBooking(It.IsAny<Booking>())).Returns(booking);
            var controller = new BookingController(mock.Object);
            var result = controller.CreateBooking(bookingModel) as OkObjectResult;
            mock.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
