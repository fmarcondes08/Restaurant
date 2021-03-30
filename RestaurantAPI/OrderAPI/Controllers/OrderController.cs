using Microsoft.AspNetCore.Mvc;
using OrderAPI.Services;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public static IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get(string input)
        {
            var order = _orderService.CreateOrder(input);

            if (!string.IsNullOrEmpty(order.OrderError))
            {
                return BadRequest(order);
            }

            return Ok(order);
        }
    }
}
