using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Controllers;
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
        public void TestCreateBookingOK()
        {
            int testId = 5;
            Tourist tou = new Tourist()
            {
                Email = "s@s.com",
                Id = 1,
                Name = "s",
                LastName = "b"
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 6,
                Address = "aa",
                ContactNumber = "44",
                Name = "ss"
            };
            Booking booking = new Booking()
            {
                Id = testId,
                TotalPrice = 10,
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(2),
                HeadGuest = tou,
                Accommodation = accommodation,
                AccommodationId = 6
            };
            BookingModelIn bookingModel = new BookingModelIn()
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestEmail = booking.HeadGuest.Email,
                GuestName = booking.HeadGuest.Name,
                GuestLastName = booking.HeadGuest.LastName,
                AccommodationId = 0
            };
            Guest g1 = new Guest()
            {
                Amount = 1,
                Multiplier = 1,
                BookingId = 5,
                Booking = booking
            };
            Guest g2 = new Guest()
            {
                Amount = 2,
                Multiplier = 2,
                BookingId = 5,
                Booking = booking
            };
            Guest g3 = new Guest()
            {
                Amount = 3,
                Multiplier = 3,
                BookingId = 5,
                Booking = booking
            };
            List<Guest> gList = new List<Guest>();
            gList.Add(g1);
            gList.Add(g2);
            gList.Add(g3);
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