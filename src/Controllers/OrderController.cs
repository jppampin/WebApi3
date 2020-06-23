using System;
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
    public OrderController(IOrderRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = repository.GetAsync().Result;
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = repository.GetAsync(id).Result;
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

        repository.Add(newOrder);

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

        repository.Update(order);  

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