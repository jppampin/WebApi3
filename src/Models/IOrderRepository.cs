
using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();
        Order Get(Guid orderId);
        void Add(Order order);
        void Update(Order order);
        Order Delete(Guid orderId);
    }
}