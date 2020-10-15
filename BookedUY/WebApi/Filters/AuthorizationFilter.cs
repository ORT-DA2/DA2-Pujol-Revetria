using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;
using System;

namespace WebApi.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;

        public AuthorizationFilter(ISessionLogic sessions)
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