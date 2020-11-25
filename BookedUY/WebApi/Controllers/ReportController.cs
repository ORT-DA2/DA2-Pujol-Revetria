using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IBookingLogic bookingLogic;
        public ReportController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet]
        public IActionResult GetReport([FromQuery] string touristicSpotName,[FromQuery] DateTime start,[FromQuery] DateTime end)
        {
            List<ReportTupleReturn> report = bookingLogic.GetReport(touristicSpotName, start, end); 
            return Ok(report);
        }
    }
}
