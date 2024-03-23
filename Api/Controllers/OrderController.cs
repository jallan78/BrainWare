namespace Api.Controllers
{
  using Infrastructure;
  using Microsoft.AspNetCore.Mvc;
  using Models;

  [ApiController]
  [Route("api")]
  public class OrderController(ILogger<OrderController> logger, IOrderService orderService) : ControllerBase
  {
    private readonly IOrderService _orderService = orderService;
    private readonly ILogger<OrderController> _logger = logger;

    [HttpGet]
    [Route("order/{id}")]
    public IEnumerable<Order> GetOrders(int id = 1)
    {
        _logger.LogInformation($"{nameof(GetOrders)} called.");  
        return _orderService.GetOrdersForCompany(id);
    }
  }
}
