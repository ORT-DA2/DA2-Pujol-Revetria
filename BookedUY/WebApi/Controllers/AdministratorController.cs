using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/administrator")]
    public class AdministratorController : BookedUYController
    {
        private readonly IAdministratorLogic administratorLogic;

        public AdministratorController(IAdministratorLogic administratorLogic)
        {
            this.administratorLogic = administratorLogic;
        }


        // GET: api/<AdministratorController>
        [HttpGet]
        public IActionResult Get()
        {
            var administrators = from a in this.administratorLogic.GetAll()
                          select new AdministratorModelOut()
                          {
                              Id = a.Id,
                              Name = a.Name,
                          };
            return Ok(administrators);
        }

        // GET api/<AdministratorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Administrator administrator = from a in administratorLogic.GetById(id)
                                 select new AdministratorModelOut()
                                 {
                                     Id = a.Id,
                                     Name = a.Name,
                                 };
            return Ok(administrator);
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
