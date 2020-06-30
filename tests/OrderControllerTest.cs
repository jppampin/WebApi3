using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Shouldly;
using WebApi;
using WebApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace WebApiTests
{
    public class OrderControllerTest
    {
        private InMemoryApplicationFactory<Startup> factory;
      
        public OrderControllerTest()
        {
            this.factory = new InMemoryApplicationFactory<Startup>();
        }

        [Fact]
        public async Task get_orders_should_be_ok()
        {
            var client = factory.CreateClient();

            var result = await client.GetAsync("/order");

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<Order[]>(json);

            orders.ShouldNotBeNull();
            orders.Length.ShouldBe(5);     
        }

        [Fact]
        public async Task get_specific_order_should_be_ok()
        {
            var guid = "5f146312-26c6-49d5-a0e0-b1e1d38b91fd";
            var path = $"/order/{guid}";
            var client = factory.CreateClient();
            var result = await client.GetAsync(path);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var order = JsonSerializer.Deserialize<Order>(json, options);

            order.Currency.ShouldBe("ARS");
            order.ItemsIds.ShouldBe(new string[] {"1", "2", "3"});
        }
    }
}
