using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SessionInterface;
using WebApi.DTOs;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/administrator")]
    public class AdministratorController : BookedUYController
    {
        private readonly IAdministratorLogic administratorLogic;
        private readonly ISessionLogic sessionLogic;

        public AdministratorController(IAdministratorLogic administratorLogic, ISessionLogic session)
        {
            this.administratorLogic = administratorLogic;
            this.sessionLogic = session;
        }


        [HttpGet("login")]
        public IActionResult Login([FromQuery]string email, [FromQuery] string password)
        {
            Administrator admin = this.administratorLogic.GetByEmailAndPassword(email, password);
            string token = sessionLogic.GenerateToken(admin);
            return Ok(token);
        }

        // DELETE api/<AdministratorController>/5
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.administratorLogic.Delete(this.administratorLogic.GetById(id));
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult CreateAdmin(AdministratorModelIn newAdministrator)
        {
            var admin = newAdministrator.FromModelInToAdministrator();
            var response = this.administratorLogic.AddAdministrator(admin);
            return Ok(response);
        }
    }
}
