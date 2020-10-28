using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/reports")]
    public class ReportController : BookedUYController
    {
        private IBookingLogic bookingLogic;
        public ReportController(IBookingLogic bookingLogic)
        {
            this.bookingLogic = bookingLogic;
        }
        // GET api/<ReportController>/5
        [HttpGet]
        public IActionResult GetReport([FromQuery] string touristicSpotName,[FromQuery] DateTime start,[FromQuery] DateTime end)
        {
            List<(string, int)> report = bookingLogic.GetReport(touristicSpotName, start, end); 
            return Ok(report);
        }
    }
}
