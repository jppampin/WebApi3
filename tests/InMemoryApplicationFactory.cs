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
        // protected override void ConfigureWebHost(IWebHostBuilder builder)
        // {
        //     builder
        //         .UseEnvironment("Testing")
        //         .ConfigureTestServices(
        //             services  => 
        //             {
        //                 var options = new DbContextOptionsBuilde<ApiDbContext>()
        //                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //                     .Options;
                        
        //                 services.AddScoped<ApiDbContext>(serviceProvider =>
        //                     new TestCatalogContext(options));   
        //             }
        //         );
                
        // }
    }
}