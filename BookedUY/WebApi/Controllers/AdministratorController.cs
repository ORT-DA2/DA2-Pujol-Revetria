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
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Migrations.Controllers
{
    [Route("api/administrator")]
    public class AdministratorController : BookedUYController
    {
        private readonly IAdministratorLogic administratorLogic;
        private readonly IConfiguration _configuration;

        public AdministratorController(IAdministratorLogic administratorLogic, IConfiguration configuration)
        {
            this.administratorLogic = administratorLogic;
            this._configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            Administrator admin = this.administratorLogic.GetByEmailAndPassword(email, password);
            return Ok(admin);
        }

        // DELETE api/<AdministratorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
