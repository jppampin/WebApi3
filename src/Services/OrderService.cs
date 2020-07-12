using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories.Generic;
using System.Linq;

namespace WebApi.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private IRepository<Order> OrderRespository => unitOfWork.OrderRepository;

        
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await OrderRespository.GetAllAsync();
        }
    }
}