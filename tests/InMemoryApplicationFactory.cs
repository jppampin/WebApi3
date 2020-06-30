using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;

namespace WebApiTests
{
    public class InMemoryApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(
                    services  => 
                    {
                        var options = new DbContextOptionsBuilder<ApiDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
                        
                        var testApiContext = new TestApiContext(options);

                        testApiContext.Database.EnsureCreated();
                        
                        services.AddScoped<ApiDbContext>(serviceProvider => testApiContext);
                        
                    }
                );
                
        }
    }
}