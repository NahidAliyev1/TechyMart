using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.CartItemDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemService _cartService;

        public CartController(  ICartItemService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CreateCartItemDto dto)
        {
            var userId = User.FindFirst("id").Value; // JWT token-dən user id
            await _cartService.AddToCartAsync(userId, dto);
            return Ok("Added to cart");
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirst("id").Value;
            var result = await _cartService.GetCartAsync(userId);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = User.FindFirst("id").Value;
            await _cartService.RemoveFromCartAsync(userId, productId);
            return Ok("Removed from cart");
        }
    }
}
