using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Middlewares
{
    public class HelloMiddlewareMessage
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HelloMiddlewareMessage> logger;

        public HelloMiddlewareMessage(RequestDelegate next, ILogger<HelloMiddlewareMessage> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation("Ingresando al MiddldewareMessage ....");
            await context.Response.WriteAsync("Message Middleware...");
        }
    }
}