using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class AdministratorModelIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Administrator FromModelInToAdministrator()
        {
            Administrator admin = new Administrator()
            {
                Email = Email,
                Password = Password
            };
            return admin;
        }
    }
}
