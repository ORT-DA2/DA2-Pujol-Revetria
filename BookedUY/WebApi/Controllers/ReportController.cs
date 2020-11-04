using BusinessLogicInterface;
using Domain;
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
        [HttpGet]
        public IActionResult GetReport([FromQuery] string touristicSpotName,[FromQuery] DateTime start,[FromQuery] DateTime end)
        {
            List<ReportTupleReturn> report = bookingLogic.GetReport(touristicSpotName, start, end); 
            return Ok(report);
        }
    }
}
