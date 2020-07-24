using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Repositories;
using WebApi.Repositories.Generic;

namespace WebApi.Models
{
    public static class ModelExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<WebApi.Repositories.Generic.IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            return services.AddOpenApiDocument(settings => {
                settings.Title = "Learning API";
                settings.Version = "v1";
                settings.DocumentName = "v1";
            });
        }


        public static IMvcBuilder AddValidations(this IMvcBuilder builder)
        {
            return builder.AddFluentValidation(config => 
                config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            );
        }
    }
}