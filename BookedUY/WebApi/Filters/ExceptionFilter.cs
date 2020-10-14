using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (APIException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = ex.StatusCode,
                    Content = ex.Message
                };
            }
            catch (NullReferenceException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = "The request has a missing parameter"
                };
            }
            catch (DbUpdateException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = "The request has a missing parameter"
                };
            }
            catch (Exception ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.ToString()
                };
            }
        }
    }
}