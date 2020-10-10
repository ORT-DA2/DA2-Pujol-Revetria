using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/accommodation")]
    public class AccommodationController : BookedUYController
    {
        private readonly AccommodationLogic accommodationLogic;

        public AccommodationController(AccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }

        [HttpGet("/spot/{spot}")]
        public IActionResult GetAccommodationsInSpot(int spot)
        {
            var accommodations = from r in this.accommodationLogic.GetAvailableAccommodationBySpot(spot)
                          select new AccommodationModelOut()
                          {
                              Id = r.Id,
                              Name =r.Name,
                              Information =r.Information,
                              Address =r.Address,
                              ContactNumber = r.ContactNumber,
                              Price = r.PricePerNight
                          };
            return Ok(accommodations);
        }

        // GET api/<AcomodationController>/5 o /?id=5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

        }

        // POST api/<AcomodationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AcomodationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<AcomodationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
