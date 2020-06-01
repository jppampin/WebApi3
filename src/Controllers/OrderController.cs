using System;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public IActionResult PostOrder(Order order)
    {
        var newOrder = new Order()
        {
            Id = Guid.NewGuid(),
            ItemsIds = order.ItemsIds
        };
        
        repository.Add(newOrder);

        return CreatedAtAction(nameof(GetOrders), new { Id = order.Id});
    }
}
}