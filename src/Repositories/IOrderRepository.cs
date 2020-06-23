using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IOrderRepository: IRepository
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(Guid id);
        Order Add(Order order);
        Order Update(Order order);
    }
}