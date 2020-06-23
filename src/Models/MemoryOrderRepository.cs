
using System;
using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

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

        public Task<IEnumerable<Order>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            this.Delete(order.Id);
            this.Add(order);
        }

        Order IOrderRepository.Add(Order order)
        {
            throw new NotImplementedException();
        }

        Order IOrderRepository.Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}