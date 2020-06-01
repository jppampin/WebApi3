using Microsoft.AspNetCore.Mvc;
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
}
}