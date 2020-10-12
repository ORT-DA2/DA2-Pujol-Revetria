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
        [HttpGet("{regionId}")]
        public IActionResult GetByRegionCategory([FromQuery]int regionId,[FromQuery]List<int> categories)
        {
            var touristicSpots = from t in this.touristicSpotLogic.GetSpotsByRegionAndCategory(categories, regionId)
                                 select new TouristicSpotModelOut()
                                 {
                                     Id = t.Id,
                                     Name = t.Name,
                                     Description = t.Description,
                                     Image = t.Image.Image
                                 };
            return Ok(touristicSpots);
        }

        // POST api/<TouristicSpotController>
        [HttpPost]
        public IActionResult CreateSpot(TouristicSpotModelIn tourisitcSpotModelIn)
        {
            TouristicSpot touristicSpot = FromModelInToTouristicSpot(tourisitcSpotModelIn);
            return Ok(touristicSpotLogic.AddTouristicSpot(touristicSpot));
        }

        private TouristicSpot FromModelInToTouristicSpot(TouristicSpotModelIn modelIn)
        {
            List<CategoryTouristicSpot> listCategories = new List<CategoryTouristicSpot>();
            foreach (int item in modelIn.Categories)
            {
                CategoryTouristicSpot c = new CategoryTouristicSpot();
                c.CategoryId = item;
                listCategories.Add(c);
            }
            TouristicSpotImage image = new TouristicSpotImage();
            image.Image = modelIn.image;
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Name = modelIn.Name,
                Description = modelIn.Description,
                RegionId = modelIn.RegionId,
                Categories = listCategories,
                Image = image
            };
            return touristicSpot;
        }

        private TouristicSpotModelOut FromTouristicSpotToModelOut(TouristicSpot touristicSpot)
        {
            TouristicSpotModelOut modelOut = new TouristicSpotModelOut()
            {
                Id = touristicSpot.Id,
                Name = touristicSpot.Name,
                Description = touristicSpot.Description
            };
            return modelOut;
        }
    }
}
