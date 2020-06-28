using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Data 
{
    public class OrderContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA= "order";
        public DbSet<Order> Orders { get; set; }
        
        public OrderContext(DbContextOptions<OrderContext> options): base(options)
        {

        }

        protected  override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderEntitySchemaDefinition());
            // builder.Entity<Order>().Property(e => e.ItemsIds)
            // .HasConversion(
            //     v => string.Join(',', v),
            //     v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            base.OnModelCreating(builder);
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken token = default)
        {
            await SaveChangesAsync(token);
            return true;
        }

    }
}