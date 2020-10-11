using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/touristicspot")]
    public class TouristicSpotController : BookedUYController
    {
        private readonly ITouristicSpotLogic touristicSpotLogic;

        public TouristicSpotController(ITouristicSpotLogic touristicSpotLogic)
        {
            this.touristicSpotLogic = touristicSpotLogic;
        }


        // GET: api/<TouristicSpotController>
        [HttpGet]
        public IActionResult Get()
        {
            var touristicSpots = from t in this.touristicSpotLogic.GetSpotsByRegionAndCategory(null, -1)
                                 select new TouristicSpotModelOut()
                                 {
                                     Id = t.Id,
                                     Name = t.Name,
                                     Description = t.Description
                                 };
            return Ok(touristicSpots);
        }

        // GET: api/<TouristicSpotController>
        [HttpGet]
        public IActionResult GetByRegionCategory([FromQuery]int regionId,[FromQuery]List<int> categories)
        {
            var touristicSpots = from t in this.touristicSpotLogic.GetSpotsByRegionAndCategory(categories, regionId)
                                 select new TouristicSpotModelOut()
                                 {
                                     Id = t.Id,
                                     Name = t.Name,
                                     Description = t.Description
                                 };
            return Ok(touristicSpots);
        }

        // POST api/<TouristicSpotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
