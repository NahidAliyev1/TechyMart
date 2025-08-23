using TechyMartProject.Application.DTOs.WhislistDTO;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Application.Services.Implementations
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IMapper _mapper;

        public WishlistService(IWishlistRepository wishlistRepository,IMapper mapper)
        {
            _wishlistRepository = wishlistRepository;
            _mapper = mapper;
        }

        public async Task AddToWishlistAsync(WishlistItemCreateDto dto)
        {

            var item = _mapper.Map<WishlistItem>(dto);
            await _wishlistRepository.AddItemAsync(item);
        }

        public async Task<WishlistDto> GetUserWishlistAsync(int userId)
        {
            var wishlist = await _wishlistRepository.GetWishlistWithItemsAsync(userId);
            return _mapper.Map<WishlistDto>(wishlist);
        }

        public async Task RemoveFromWishlistAsync(int itemId)
        {
            await _wishlistRepository.RemoveItemAsync(itemId);
        }
    }
}
