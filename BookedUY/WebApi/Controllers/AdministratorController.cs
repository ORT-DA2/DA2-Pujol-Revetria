using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

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
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var administrators = from a in this.administratorLogic.GetAll();
        //    select new AdministratorModelOut()
        //    {
        //        Id = a.Id,
        //        Name = a.Name,
        //    };
        //    return Ok(administrators);
        //}

        // GET api/<AdministratorController>/5
        [HttpGet]
        public IActionResult Get(string email, string password)
        {
            Administrator admin = this.administratorLogic.GetByEmailAndPassword(email,password);
            //var ret = new AdministratorModelOut()
            //                     {
            //                         Id = admin.Id,
            //                         Email = admin.Email,
            //                     };
            return Ok(admin);
        }

        // POST api/<AdministratorController>
        [HttpPost]
        public void CreateBooking(BookingModelIn newBooking)
        {
            /*body{
             *  accommodationId: 5
             *  touristName: fa
             *  }
             */
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
