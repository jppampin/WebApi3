using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
[Route("[controller]")]
[ApiController]
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
        var orders = repository.Get();
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = repository.Get(id);
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
    public IActionResult PutOrder(Guid id, Order orderUpdated)
    {
        var order = repository.Get(id);
        if(order == null)
            return NotFound();

        order.ItemsIds = orderUpdated.ItemsIds;

        repository.Update(order);  

        return Ok(); 
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PatchOrder(Guid id, JsonPatchDocument<Order> orderPatched)
    {
        var order = repository.Get(id);
        if(order == null)
            return NotFound();

        orderPatched.ApplyTo(order);

        repository.Update(order);  

        return Ok(); 
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletOrder(Guid id)
    {
        var order = repository.Get(id);
        if(order == null)
        {
            return NotFound();
        }

        repository.Delete(id);
        return Ok();
    }
}
}