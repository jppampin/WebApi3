using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApiDbContext: DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {}

        protected  override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderEntitySchemaDefinition());
            base.OnModelCreating(builder);
            var orders = new Order[]{
                new Order() { Id = Guid.NewGuid(), Currency = "ARS", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "EUR", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "USD", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "BRL", ItemsIds = new string[] {"1", "2", "3"}}
                ,new Order() {Id = Guid.NewGuid(), Currency = "???", ItemsIds = new string[] {"1", "2", "3"}}
            };
            builder.Entity<Order>().HasData(orders);
        }

    }
}