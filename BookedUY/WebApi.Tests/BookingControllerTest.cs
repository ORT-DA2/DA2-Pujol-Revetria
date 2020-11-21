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
            Tourist tourist = new Tourist
            {
                Email = "s@s.com",
                Id = 1,
                Name = "s",
                LastName = "b"
            };
            Booking booking = new Booking
            {
                Id = 5,
                TotalPrice = 10,
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(2),
                HeadGuest = tourist
            };
            List<Booking> list = new List<Booking>
            {
                booking
            };
            var mockBooking = new Mock<IBookingLogic>(MockBehavior.Strict);
            mockBooking.Setup(p => p.GetAll()).Returns(list);
            var controller = new BookingController(mockBooking.Object);

            var result = controller.Get() as OkObjectResult;

            mockBooking.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetByIdBookingsOK()
        {
            Tourist tourist = new Tourist
            {
                Email = "s@s.com",
                Id = 1,
                Name = "s",
                LastName = "b"
            };
            Accommodation accommodation = new Accommodation
            {
                Id = 5,
                Name = "a",
                Address = "a",
                ContactNumber = "2"
            };
            Booking booking = new Booking
            {
                Id = 5,
                TotalPrice = 10,
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(2),
                HeadGuest = tourist,
                Accommodation = accommodation
            };
            Guest guest = new Guest
            {
                Amount = 1,
                Multiplier = 1
            };
            List<Guest> guestList = new List<Guest>
            {
                guest,
                guest,
                guest
            };
            booking.Guests = guestList;
            var mockBooking = new Mock<IBookingLogic>(MockBehavior.Strict);
            mockBooking.Setup(p => p.GetById(It.IsAny<int>())).Returns(booking);
            var controller = new BookingController(mockBooking.Object);

            var result = controller.Get(5) as OkObjectResult;

            mockBooking.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestCreateBookingOK()
        {
            Tourist tourist = new Tourist()
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
                Id = 5,
                TotalPrice = 10,
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(2),
                HeadGuest = tourist,
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
            Guest guest1 = new Guest()
            {
                Amount = 1,
                Multiplier = 1,
                BookingId = 5,
                Booking = booking
            };
            Guest guest2 = new Guest()
            {
                Amount = 2,
                Multiplier = 2,
                BookingId = 5,
                Booking = booking
            };
            Guest guest3 = new Guest()
            {
                Amount = 3,
                Multiplier = 3,
                BookingId = 5,
                Booking = booking
            };
            List<Guest> guestList = new List<Guest>
            {
                guest1,
                guest2,
                guest3
            };
            bookingModel.Guests = guestList;
            var mockBooking = new Mock<IBookingLogic>(MockBehavior.Strict);
            mockBooking.Setup(p => p.AddBooking(It.IsAny<Booking>())).Returns(booking);
            var controller = new BookingController(mockBooking.Object);

            var result = controller.CreateBooking(bookingModel) as OkObjectResult;

            mockBooking.VerifyAll();
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}