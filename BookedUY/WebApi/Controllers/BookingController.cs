using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
                           select new BookingModelOut()
                           {
                               Id = b.Id,
                               AccommodationId = b.AccommodationId,
                               AccommodationName = b.Accommodation.Name,
                               AccommodationAddress = b.Accommodation.Address,
                               AccommodationContact = b.Accommodation.ContactNumber,
                               CheckIn = b.CheckIn,
                               CheckOut = b.CheckOut,
                               Price = b.TotalPrice,
                               GuesEmail = b.HeadGuest.Email
                           };
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = this.bookingLogic.GetById(id);
            var booking = new BookingModelOut()
            {
                Id = b.Id,
                AccommodationId = b.AccommodationId,
                AccommodationName = b.Accommodation.Name,
                AccommodationAddress = b.Accommodation.Address,
                AccommodationContact = b.Accommodation.ContactNumber,
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
                Price = b.TotalPrice,
                GuesEmail = b.HeadGuest.Email
            };
            return Ok(booking);
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
