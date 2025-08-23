using TechyMartProject.Application.DTOs.CartItemDTO;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Application.Services.Implementations;
public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public CartItemService(ICartItemRepository cartItemRepository,IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task AddToCartAsync(string userId, CreateCartItemDto dto)
    {
        var cartItems = await _cartItemRepository.GetCartByUserIdAsync(userId);
        var existing = cartItems.FirstOrDefault(c => c.ProductId == dto.ProductId);

        if (existing == null)
        {
            var newItem = _mapper.Map<CartItem>(dto);
            newItem.UserID = userId;
            await _cartItemRepository.CreateAsync(newItem);
        }
        else
        {
            existing.Quantity += dto.Quantity;
             _cartItemRepository.Update(existing);
        }
    }

    public async Task<List<GetCartItemDto>> GetCartAsync(string userId)
    {
        var cartItems = await _cartItemRepository.GetCartByUserIdAsync(userId);
        return _mapper.Map<List<GetCartItemDto>>(cartItems);
    }

    public async  Task RemoveFromCartAsync(string userId, int productId)
    {
        var cartItems = await _cartItemRepository.GetCartByUserIdAsync(userId);
        var item = cartItems.FirstOrDefault(c => c.ProductId == productId);

        if (item != null)
        {
             _cartItemRepository.Delete(item);
        }
    }
}
