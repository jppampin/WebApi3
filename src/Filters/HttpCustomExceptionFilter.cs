using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Filters
{
    public class HttpCustomExceptionFilter : IExceptionFilter
        {
            public HttpCustomExceptionFilter()
            {
            }
            public void OnException(ExceptionContext context)
            {
                var logger = context.HttpContext.RequestServices.GetService<ILogger<HttpCustomExceptionFilter>>();
                var json = new { Message = $"{context.Exception.Message} - Global Captured"};
                logger.LogError("Exception atrapada por el filtro", context.Exception);

                var exceptionResult = new ObjectResult(json)
                {
                    StatusCode = (int) HttpStatusCode.InternalServerError
                };

                context.Result = exceptionResult;
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }
        }
}