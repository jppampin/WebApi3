using Microsoft.Extensions.DependencyInjection;
using WebApi.Repositories;

namespace WebApi.Models
{
    public static class ModelExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            return services.AddOpenApiDocument(settings => {
                settings.Title = "Learning API";
                settings.Version = "v1";
                settings.DocumentName = "v1";
            });
        }
    }
}