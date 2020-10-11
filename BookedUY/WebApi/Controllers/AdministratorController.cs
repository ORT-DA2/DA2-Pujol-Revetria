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
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            Administrator admin = this.administratorLogic.GetByEmailAndPassword(email, password);
            //if (admin != null)
            //{
            //    var secretKey = _configuration.GetValue<string>("SecretKey");
            //    var key = Encoding.ASCII.GetBytes(secretKey);

            //    // Creamos los claims (pertenencias, características) del usuario
            //    var claims = new[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, user.UserId),
            //        new Claim(ClaimTypes.Email, user.Email)
            //    };

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = claims,
            //        // Nuestro token va a durar un día
            //        Expires = DateTime.UtcNow.AddDays(1),
            //        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };

            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            //    return tokenHandler.WriteToken(createdToken);
            //}
        }
            return Ok(admin);
        }

        // DELETE api/<AdministratorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
