using Microsoft.Extensions.DependencyInjection;
using WebApi.Repositories;

namespace WebApi.Models
{
    public static class ModelExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddSingleton<IOrderRepository, MemoryOrderRepository>();
        }
    }
}