using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.OrderDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{orderNo}")]
        public async Task<ActionResult<OrderSummeryDto>> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var result = await _orderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByNo), new { orderNo = result.OrderNo }, result);
        }

        [HttpGet]

        public async Task<ActionResult<OrderSummeryDto>> GetByNo(string orderNo)
        {
            var order = await _orderService.PayAsync(orderNo);
            return Ok(order);
        }

        [HttpPost("{orderNo}/pay")]
        public async Task<ActionResult<OrderSummeryDto>> Pay(string orderNo)
        {
            var result = await _orderService.PayAsync(orderNo);
            return Ok(result);
        }

        [HttpPost("{orderNo}/cancel")]
        public async Task<IActionResult> Cancel(string orderNo)
        {
            await _orderService.CancelAsync(orderNo);
            return NoContent();
        }
    }
}
