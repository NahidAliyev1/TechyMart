using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.WhislistDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWishlist(int userId)
        {
            var result = await _wishlistService.GetUserWishlistAsync(userId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToWishlist([FromBody] WishlistItemCreateDto dto)
        {
            await _wishlistService.AddToWishlistAsync(dto);
            return Ok("Product added to wishlist.");
        }

        [HttpDelete("remove/{itemId}")]
        public async Task<IActionResult> RemoveFromWishlist(int itemId)
        {
            await _wishlistService.RemoveFromWishlistAsync(itemId);
            return Ok("Product removed from wishlist.");
        }
    }
}
