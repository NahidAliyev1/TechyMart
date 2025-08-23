using TechyMartProject.Application.DTOs.WhislistDTO;

namespace TechyMartProject.Application.Services.Services
{
    public interface IWishlistService
    {
        Task<WishlistDto> GetUserWishlistAsync(int userId);
        Task AddToWishlistAsync(WishlistItemCreateDto dto);
        Task RemoveFromWishlistAsync(int itemId);
    }
}
