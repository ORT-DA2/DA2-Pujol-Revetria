using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/regions")]
    public class RegionController : BookedUYController
    {
        private IRegionLogic regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            this.regionLogic = regionLogic;
        }

        // GET: api/<RegionController>
        [HttpGet]
        public IActionResult Get()
        {
            var regions = from region in this.regionLogic.GetRegions()
            select new RegionModelOut(region);
            return Ok(regions);
        }
    }
}