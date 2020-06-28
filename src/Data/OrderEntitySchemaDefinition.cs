using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data
{
    public class OrderEntitySchemaDefinition : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", OrderContext.DEFAULT_SCHEMA);
            builder.HasKey( e => e.Id);
            builder.Property( p => p.Currency).IsRequired(); 
            builder.Property(e => e.ItemsIds)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}