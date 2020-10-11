using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingStageController : ControllerBase
    {
        private readonly IBookingStageLogic bookingStageLogic;

        public BookingStageController(IBookingStageLogic bookingStageLogic)
        {
            this.bookingStageLogic = bookingStageLogic;
        }


        // GET api/<BookingStageController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookingStatus(int id)
        {
            var stage = this.bookingStageLogic.GetCurrentStatusByBooking(id);
            var response = new BookingStageModelOut()
            {
                Descripcion = stage.Description,
                Status = stage.Status.ToString(),
            };
            return Ok(response);
        }

        // POST api/<BookingStageController>
        [HttpPost]
        public IActionResult NewStage(BookingStageModelIn newStage)
        {
            var stage = new BookingStage()
            {
                Description = newStage.Description,
                AdministratorId = newStage.AdminId,
                AsociatedBookingId = newStage.BookingId,
                Status = StatusMethods.StringToStatus(newStage.Status),
            };
            return Ok(stage);
        }
    }
}
