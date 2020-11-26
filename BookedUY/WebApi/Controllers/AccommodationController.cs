using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DTOs;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/accommodations")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationLogic accommodationLogic;

        public AccommodationController(IAccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet]
        public IActionResult Get()
        {
            var accommodations = from accommodation in this.accommodationLogic.GetAll()
            select new AccommodationModelOut(accommodation, this.accommodationLogic.GetReviewsByAccommodation(accommodation.Id));
            return Ok(accommodations);
        }

        [HttpGet("spot/{spot}")]
        public IActionResult GetAccommodationsInSpot(int spot)
        {
            var accommodations = from accommodation in this.accommodationLogic.GetAvailableAccommodationBySpot(spot)
            select new AccommodationModelOut(accommodation,this.accommodationLogic.GetReviewsByAccommodation(accommodation.Id));
            return Ok(accommodations);
        }

        // GET api/<AcomodationController>/5 o /?id=5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Accommodation accommodation = this.accommodationLogic.GetById(id);
            var response = new AccommodationModelOut(accommodation, this.accommodationLogic.GetReviewsByAccommodation(id));
            return Ok(response);
        }

        [HttpPost("review")]
        public IActionResult CreateReview(ReviewModelIn newAccommodation)
        {
            var review = newAccommodation.ToReview();
            var response = this.accommodationLogic.AddReview(review);
            return Ok(new ReviewModelOut(response));
        }

        // POST api/<AcomodationController>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult CreateAccommodation(AccommodationModelIn newAccommodation)
        {
            var accommodation = newAccommodation.FromModelInToAccommodation();
            var response = this.accommodationLogic.AddAccommodation(accommodation);
            return Ok(new AccommodationModelOut(response,(0,new List<Review>())));
        }

        // PUT api/<AcomodationController>/5
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPut("{id}")]
        public IActionResult UpdateCapacity(int id, [FromBody] StatusModelIn statusModelIn)
        {
            this.accommodationLogic.UpdateCapacity(id, statusModelIn.Status);
            return Ok("Accommodation Updated");
        }

        // DELETE api/<AcomodationController>/5
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var accommodationToDelete = this.accommodationLogic.GetById(id);
            var response = this.accommodationLogic.DeleteAccommodation(accommodationToDelete);
            return Ok(response);
        }
    }
}