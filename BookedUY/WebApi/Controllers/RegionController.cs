using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Migrations.Controllers;
using WebApi.DTOs;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers 
{
    [Route("api/[controller]")]
    public class RegionController : BookedUYController
    {
        private IRegionLogic regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            this.regionLogic = regionLogic;
        }


        // GET: api/<RegionController>
        [HttpGet]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Get()
        {
            var regions = from r in this.regionLogic.GetRegions()
                          select new RegionModelOut()
                          {
                              Id = r.Id,
                              Name = r.Name,
                          };
            return Ok(regions);
        }
    }
}
