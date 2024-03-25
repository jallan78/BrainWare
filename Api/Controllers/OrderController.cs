namespace Api.Controllers
{
    using Contract;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
  [Route("api")]
  public class OrderController(ILogger<OrderController> logger, IOrderService orderService) : ControllerBase
  {
    private readonly IOrderService _orderService = orderService;
    private readonly ILogger<OrderController> _logger = logger;

    [HttpGet]
    [Route("order/{id}")]
    public async Task<IList<OrderDto>> GetOrders(int id = 1)
    {
        _logger.LogInformation($"{nameof(GetOrders)} called.");  

        return await _orderService.GetOrdersListAsync(id);
    }
  }
}
