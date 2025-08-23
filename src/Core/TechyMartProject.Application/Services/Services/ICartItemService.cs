using TechyMartProject.Application.DTOs.CartItemDTO;

namespace TechyMartProject.Application.Services.Services;
public interface ICartItemService
{
    Task AddToCartAsync(string userId, CreateCartItemDto dto);
    Task<List<GetCartItemDto>> GetCartAsync(string userId);
    Task RemoveFromCartAsync(string userId, int productId);
}
