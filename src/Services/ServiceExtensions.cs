using Microsoft.Extensions.DependencyInjection;
using WebApi.Mappers;

namespace WebApi.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<OrderMapper>();

            return services;
        }
    }
}