using TechyMartProject.Application.DTOs.CartItemDTO;

namespace TechyMartProject.Application.Profiles;
public class CartItemProfile:Profile
{
    public CartItemProfile()
    {
        CreateMap<CartItem, GetCartItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        CreateMap<CreateCartItemDto, CartItem>();
    }
}
