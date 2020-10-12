
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
            catch (InvalidImageException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.Message
                };
            }
            catch (Exception ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = ex.ToString()
                };
            }
        }
    }
}
