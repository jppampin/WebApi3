using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Data
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddApiDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApiDbContext>( contextOptions =>
                                                    contextOptions.UseSqlite(
                                                        connectionString
                                                        ,serverOptions => serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName)
                                                    )
            );
        }

        public static IServiceCollection AddOrderContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<OrderContext>( contextOptions =>
                                                    contextOptions.UseSqlite(
                                                        connectionString
                                                        ,serverOptions => serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName)
                                                    )
            );
        }
    }
}