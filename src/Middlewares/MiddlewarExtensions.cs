using Microsoft.AspNetCore.Builder;

namespace WebApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.Map("/hello", _ => _.UseMiddleware<HelloMiddlewareMessage>());
            return builder.UseMiddleware<HelloMiddleware>();
        }
    }
}