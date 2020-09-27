using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void GetBookings()
        {

        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            
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
