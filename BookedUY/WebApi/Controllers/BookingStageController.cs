using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/bookingstages")]
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
            var response = new BookingStageModelOut(stage);
            return Ok(response);
        }

        // POST api/<BookingStageController>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult NewStage(BookingStageModelIn newStage)
        {
            var stage = newStage.FromModelInToBookingStage();
            var response = this.bookingStageLogic.AddBookingStage(stage);
            return Ok(new BookingStageModelOut(response));
        }
    }
}