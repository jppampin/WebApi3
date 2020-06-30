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
        }

    }
}