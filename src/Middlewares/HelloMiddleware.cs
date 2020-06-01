using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Middlewares
{
    public class HelloMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HelloMiddleware> logger;

        public HelloMiddleware(RequestDelegate next, ILogger<HelloMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Custom", "Hello Middleware!");
            logger.LogInformation("Ingresando al Middldeware ....");
            await next(context);
        }
    }
}