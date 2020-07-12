using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IOrderService, OrderService>();
        }
    }
}