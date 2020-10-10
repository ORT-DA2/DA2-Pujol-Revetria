using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
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
        public void Get()
        {
            var bookings = from b in this.bookingLogic.GetAll()
                          select new BookingModelOut()
                          {
                              Id = r.Id,
                              Name = r.Name,
                          };
            return Ok(bookings);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            var book = this.bookingLogic.GetById(id);
            var booking = new BookingModelOut()
                           {
                                
                           };
            return Ok(bookings);
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
