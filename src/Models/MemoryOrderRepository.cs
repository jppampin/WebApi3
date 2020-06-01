
using System;
using System.Collections.Generic;
using WebApi.Models;
using System.Linq;

namespace WebApi.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        private IList<Order> orders { get; set;} = new List<Order>();
        public void Add(Order order)
        {
            this.orders.Add(order);
        }

        public Order Delete(Guid orderId)
        {
            var order = orders.FirstOrDefault( o => o.Id == orderId);
            if(orders != null)
                orders.Remove(order);
            
            return order;
        }

        public IEnumerable<Order> Get()
        {
            return this.orders;
        }

        public Order Get(Guid orderId)
        {
            return this.orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void Update(Order order)
        {
            this.Delete(order.Id);
            this.Add(order);
        }
    }
}