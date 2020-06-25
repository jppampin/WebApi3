using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
[Route("[controller]")]
[ApiController]
//[CustomExceptionAttribute]
public class OrderController: ControllerBase
{
    IOrderRepository repository;
    WebApi.Repositories.Generic.IUnitOfWork unitOfWork;
    public OrderController(IOrderRepository repository, WebApi.Repositories.Generic.IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        //var orders = repository.GetAsync().Result;
        var orders = await unitOfWork.OrderRepository.ReadOnlyAsyncEntries;
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var order = await repository.GetAsync(id);
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

        unitOfWork.OrderRepository.Add(newOrder);
        unitOfWork.CommitAsync();
        

        return CreatedAtAction(nameof(GetOrders), new { Id = newOrder.Id});
    }

    [HttpPut("{id:guid}")]
    [OrderExists]
    public IActionResult PutOrder(Guid id, Order orderUpdated)
    {
        var order = repository.GetAsync(id).Result;
        if(order == null)
            return NotFound();

        order.ItemsIds = orderUpdated.ItemsIds;
        order.Currency = orderUpdated.Currency;

        unitOfWork.OrderRepository.Update(order);
        unitOfWork.CommitAsync();  

        return Ok(); 
    }

    [HttpGet("exception")]
    public IActionResult GetException()
    {
        throw new ApplicationException("Testing exception");
    } 

    [HttpPatch("{id:guid}")]
    [OrderExists]
    public IActionResult PatchOrder(Guid id, JsonPatchDocument<Order> orderPatched)
    {
        // var order = repository.Get(id);
        // if(order == null)
        //     return NotFound();

        var order = repository.GetAsync(id).Result;
        orderPatched.ApplyTo(order);
        repository.Update(order);  

        return Ok(); 
    }

    [HttpDelete("{id:guid}")]
    [OrderExists]
    public IActionResult DeletOrder(Guid id)
    {
        // var order = repository.Get(id);
        // if(order == null)
        // {
        //     return NotFound();
        // }

        // repository.Delete(id);
        return Ok();
    }
}
}