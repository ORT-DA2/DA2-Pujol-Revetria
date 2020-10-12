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

        [HttpGet("/spot/{spot}")]
        public IActionResult GetAccommodationsInSpot(int spot)
        {
            var accommodations = from r in this.accommodationLogic.GetAvailableAccommodationBySpot(spot)
                                 select new AccommodationModelOut()
                                 {
                                     Id = r.Id,
                                     Name = r.Name,
                                     Information = r.Information,
                                     Address = r.Address,
                                     ContactNumber = r.ContactNumber,
                                     Price = r.PricePerNight
                                 };
            return Ok(accommodations);
        }

        
        // GET api/<AcomodationController>/5 o /?id=5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Accommodation a = this.accommodationLogic.GetById(id);
            var ret = new AccommodationModelOut()
            {
                Id = a.Id,
                Name = a.Name,
                Information = a.Information,
                Address = a.Address,
                ContactNumber = a.ContactNumber,
                Price = a.PricePerNight,
            };
            return Ok(ret);
        }

        // POST api/<AcomodationController>
        [HttpPost]
        public IActionResult CreateAccommodation(AccommodationModelIn newAccommodation)
        {
            var accom = new Accommodation()
            {
                Address = newAccommodation.Address,
                ContactNumber = newAccommodation.Contact,
                Information = newAccommodation.Information,
                Name = newAccommodation.Name,
                PricePerNight = newAccommodation.Price,
                SpotId = newAccommodation.SpotId
            };
            var response = this.accommodationLogic.AddAccommodation(accom);
            return Ok(response);
        }

        // PUT api/<AcomodationController>/5
        [HttpPut("{id}")]
        public void UpdateCapacity(int id, [FromBody] bool status)
        {
            this.accommodationLogic.UpdateCapacity(id, status);
        }

        // DELETE api/<AcomodationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var accomToDelete = this.accommodationLogic.GetById(id);
            this.accommodationLogic.DeleteAccommodation(accomToDelete);
        }
    }
}
