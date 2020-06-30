using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApiTests
{
    public class TestApiContext: ApiDbContext
    {
        public TestApiContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var orders = new Order[]{
                new Order() { Id = Guid.Parse("5f146312-26c6-49d5-a0e0-b1e1d38b91fd"), Currency = "ARS", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "EUR", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "USD", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "BRL", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "???", ItemsIds = new string[] {"1", "2", "3"}}
            };
            builder.Entity<Order>().HasData(orders);
        }
        
    }
    
}