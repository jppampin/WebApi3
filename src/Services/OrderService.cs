using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories.Generic;
using WebApi.Mappers;

namespace WebApi.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;
        private OrderMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, OrderMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper; 
        }

        private IRepository<Order> OrderRespository => unitOfWork.OrderRepository;

        
        public async Task<IEnumerable<OrderResponse>> GetOrdersAsync()
        {
            var orders = await OrderRespository.GetAllAsync();
            return mapper.Map(orders); 
        }
    }
}