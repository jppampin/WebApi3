using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data
{
    public class OrderEntitySchemaDefinition : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var valueComparer = new ValueComparer<IEnumerable<string>>(
                (c1, c2) => c1.SequenceEqual(c2), 
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => (IEnumerable<string>)c.ToHashSet());

            builder.ToTable("Orders");
            builder.HasKey( e => e.Id);
            builder.Property( p => p.Currency).IsRequired(); 
            builder.Property(e => e.ItemsIds)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Metadata.SetValueComparer(valueComparer);
        }
    }
}