using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionLogic regionLogic;

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