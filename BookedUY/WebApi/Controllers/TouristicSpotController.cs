using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TouristicSpotController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TouristicSpotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TouristicSpotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TouristicSpotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
