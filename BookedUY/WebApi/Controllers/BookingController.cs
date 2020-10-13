using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace Migrations.Controllers
{
    [Route("api/booking")]
    public class BookingController : BookedUYController
    {
        private readonly IBookingLogic bookingLogic;
        public BookingController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IActionResult Get()
        {
            var bookings = from b in this.bookingLogic.GetAll()
                           select new BookingModelOut(b);
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var b = this.bookingLogic.GetById(id);
            var booking = new BookingModelOut(b);
            return Ok(booking);
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult CreateBooking(BookingModelIn newBooking)
        {
            var booking = newBooking.FromModelInToBooking();
            var response = this.bookingLogic.AddBooking(booking);
            return Ok(new BookingModelOut(response));
        }
    }
}
