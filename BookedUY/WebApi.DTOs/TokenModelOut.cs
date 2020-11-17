using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class TokenModelOut
    { 
        public string Token { get; set; }

        public TokenModelOut(string token)
        {
            Token = token;
        }
    }
}
