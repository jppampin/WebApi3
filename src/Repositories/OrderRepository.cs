using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories 
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => context;

        public Order Add(Order order)
        {
            return context.Orders.Add(order).Entity;
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetAsync(Guid id)
        {
            return await context.Orders.AsNoTracking()
                    .Where( x => x.Id == id).FirstOrDefaultAsync();
        }

        public Order Update(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            return order;
        }
    }
}