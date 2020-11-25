using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using SessionInterface;
using System.Linq;
using WebApi.DTOs;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/administrators")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorLogic administratorLogic;
        private readonly ISessionLogic sessionLogic;

        public AdministratorController(IAdministratorLogic administratorLogic, ISessionLogic session)
        {
            this.administratorLogic = administratorLogic;
            this.sessionLogic = session;
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            Administrator administrator = this.administratorLogic.GetByEmailAndPassword(email, password);
            string token = sessionLogic.GenerateToken(administrator);
            return Ok(new TokenModelOut(token));
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet()]
        public IActionResult Get()
        {
            var administrators = from administrator in this.administratorLogic.GetAll()
            select new AdministratorModelOut(administrator.Email, administrator.Id);
            return Ok(administrators);
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
            var administrator = newAdministrator.FromModelInToAdministrator();
            this.administratorLogic.AddAdministrator(administrator);
            return Ok("Administrator Created Successfully");
        }
    }
}