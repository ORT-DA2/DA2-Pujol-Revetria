using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/administrator")]
    public class AdministratorController : BookedUYController
    {
        private readonly IUserLogic userLogic;

        public AdministratorController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }


        // GET: api/<AdministratorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdministratorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdministratorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdministratorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdministratorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
