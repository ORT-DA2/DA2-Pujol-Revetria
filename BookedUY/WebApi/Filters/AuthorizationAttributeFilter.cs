using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class AuthorizationAttributeFilte : IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;

        public AuthorizationAttributeFilte(ISessionLogic sessions)
        {
            this.sessions = sessions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];
            if (String.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No token provided"
                };
            }
            else
            {
                if (!sessions.IsCorrectToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Not authorized"
                    };
                }
            }
        }
    }
}

