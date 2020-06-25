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
            builder.Entity<Order>().Property(e => e.ItemsIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            base.OnModelCreating(builder);
        }

    }
}