using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/acomodation")]
    public class AcomodationController : BookedUYController
    {
        private readonly AccommodationLogic accommodationLogic;

        public AcomodationController(AccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }

        [HttpGet("{spot}")]
        public IEnumerable<string> GetAccommodationsInSpot()
        {
            return null;
        }

        // GET api/<AcomodationController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            return Ok();
        }

        // POST api/<AcomodationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AcomodationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<AcomodationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
