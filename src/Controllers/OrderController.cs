using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Models;
using WebApi.Repositories.Generic;
using WebApi.Services;

namespace WebApi.Controllers
{
[Route("[controller]")]
[ApiController]
//[CustomExceptionAttribute]
public class OrderController: ControllerBase
{
    WebApi.Repositories.Generic.IUnitOfWork unitOfWork;

    private IOrderService orderService;

    private IRepository<Order> Repository => unitOfWork.OrderRepository;
    private Repositories.Generic.IUnitOfWork UnitOfWork => unitOfWork;

    private IOrderService OrderService => orderService;
    public OrderController(WebApi.Repositories.Generic.IUnitOfWork unitOfWork, IOrderService orderService)
    {
        this.unitOfWork = unitOfWork;
        this.orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await OrderService.GetOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    [OrderExists]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var order = await Repository.GetByIdAsync(id);
        return Ok(order);
    }

    [HttpPost]
    public IActionResult PostOrder(OrderRequest order)
    {
        var newOrder = new Order()
        {
            Id = Guid.NewGuid(),
            ItemsIds = order.ItemsIds,
            Currency = order.Currency
        };

        Repository.Add(newOrder);
        UnitOfWork.CommitAsync();
        
        return CreatedAtAction(nameof(GetOrders), new { Id = newOrder.Id});
    }

    [HttpPut("{id:guid}")]
    [OrderExists]
    public async Task<IActionResult> PutOrder(Guid id, Order orderUpdated)
    {
        var order = await Repository.GetByIdAsync(id);
        if(order == null)
            return NotFound();

        order.ItemsIds = orderUpdated.ItemsIds;
        order.Currency = orderUpdated.Currency;

        Repository.Update(order);
        UnitOfWork.CommitAsync();  

        return Ok(); 
    }

    [HttpGet("exception")]
    public IActionResult GetException()
    {
        throw new ApplicationException("Testing exception");
    } 

    [HttpPatch("{id:guid}")]
    [OrderExists]
    public async Task<IActionResult> PatchOrder(Guid id, JsonPatchDocument<Order> orderPatched)
    {
        var order = await Repository.GetByIdAsync(id);
        
        orderPatched.ApplyTo(order);

        Repository.Update(order);
        UnitOfWork.CommitAsync();  

        return Ok(); 
    }

    [HttpDelete("{id:guid}")]
    [OrderExists]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await Repository.GetByIdAsync(id);
        
        Repository.Remove(order);
        UnitOfWork.CommitAsync();

        return Ok();
    }
}
}