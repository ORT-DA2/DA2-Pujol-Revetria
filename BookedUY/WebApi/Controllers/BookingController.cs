﻿using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DTOs;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingLogic bookingLogic;

        public BookingController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }

        // GET: api/<BookingController>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet]
        public IActionResult Get()
        {
            var bookings = from booking in this.bookingLogic.GetAll()
            select new BookingModelOut(booking);
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = this.bookingLogic.GetById(id);
            var bookingModelOut = new BookingModelOut(booking);
            return Ok(bookingModelOut);
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult CreateBooking(BookingModelIn newBooking)
        {
            var booking = newBooking.FromModelInToBooking();
            var response = this.bookingLogic.AddBooking(booking);
            response.Accommodation = new Accommodation();
            return Ok(new BookingModelOut(response));
        }
    }
}