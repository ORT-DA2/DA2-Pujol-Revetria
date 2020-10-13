using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Filters;

namespace Migrations.Controllers
{
    [Route("api/accommodation")]
    public class AccommodationController : BookedUYController
    {
        private readonly IAccommodationLogic accommodationLogic;

        public AccommodationController(IAccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }

        [HttpGet("spot/{spot}")]
        public IActionResult GetAccommodationsInSpot(int spot)
        {
            var accommodations = from r in this.accommodationLogic.GetAvailableAccommodationBySpot(spot)
                                 select new AccommodationModelOut(r);
            return Ok(accommodations);
        }

        
        // GET api/<AcomodationController>/5 o /?id=5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Accommodation a = this.accommodationLogic.GetById(id);
            var ret = new AccommodationModelOut(a);
            return Ok(ret);
        }

        // POST api/<AcomodationController>
        [HttpPost]
        public IActionResult CreateAccommodation(AccommodationModelIn newAccommodation)
        {
            var accom = newAccommodation.FromModelInToAccommodation();
            var response = this.accommodationLogic.AddAccommodation(accom);
            return Ok(new AccommodationModelOut(response));
        }

        // PUT api/<AcomodationController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCapacity(int id, [FromBody] bool status)
        {
            this.accommodationLogic.UpdateCapacity(id, status);
            return Ok("Accommodation Updated");
        }

        // DELETE api/<AcomodationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var accomToDelete = this.accommodationLogic.GetById(id);
            var ret =this.accommodationLogic.DeleteAccommodation(accomToDelete);
            return Ok(ret);
        }
    }
}
