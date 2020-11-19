using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class AdministratorModelOut
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public AdministratorModelOut(string email, int id)
        {
            Id = id;
            Email = email;
        }
    }
}
