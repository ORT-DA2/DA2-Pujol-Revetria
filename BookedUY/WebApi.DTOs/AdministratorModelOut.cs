using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class AdministratorModelOut
    {
        public string Email { get; set; }
        public AdministratorModelOut(string email)
        {
            Email = email;
        }
    }
}
