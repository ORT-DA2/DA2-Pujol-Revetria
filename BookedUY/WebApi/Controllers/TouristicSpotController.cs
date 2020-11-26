using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DTOs;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/touristicspots")]
    [ApiController]
    public class TouristicSpotController : ControllerBase
    {
        private readonly ITouristicSpotLogic touristicSpotLogic;

        public TouristicSpotController(ITouristicSpotLogic touristicSpotLogic)
        {
            this.touristicSpotLogic = touristicSpotLogic;
        }

        // GET: api/<TouristicSpotController>
        public IActionResult Get()
        {
            var touristicSpots = from touristicSpot in this.touristicSpotLogic.GetSpotsByRegionAndCategory(null, -1)
            select new TouristicSpotModelOut(touristicSpot);
            return Ok(touristicSpots);
        }

        // GET: api/<TouristicSpotController>
        [HttpGet]
        public IActionResult GetByRegionCategory([FromQuery] int regionId, [FromQuery] List<int> categories)
        {
            if (regionId <= 0 && (categories == null || categories.Count == 0))
            {
                return Get();
            }
            var touristicSpots = from touristicSpot in this.touristicSpotLogic.GetSpotsByRegionAndCategory(categories, regionId)
            select new TouristicSpotModelOut(touristicSpot);
            return Ok(touristicSpots);
        }

        // POST api/<TouristicSpotController>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult CreateSpot(TouristicSpotModelIn touristicSpotModelIn)
        {
            TouristicSpot touristicSpot = touristicSpotModelIn.FromModelInToTouristicSpot();
            var response = new TouristicSpotModelOut(touristicSpotLogic.AddTouristicSpot(touristicSpot));
            return Ok(response);
        }
    }
}