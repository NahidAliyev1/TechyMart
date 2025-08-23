using TechyMartProject.Application.DTOs.WhislistDTO;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Application.Profiles
{
    public class WishlistProfile:Profile
    {
        public WishlistProfile()
        {
            CreateMap<Whislist, WishlistDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.WishlistItems));

            CreateMap<WishlistItem, WishlistItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<CreateWhislistDto, Whislist>();
            CreateMap<WishlistItemCreateDto, WishlistItem>();
        }
    }
}
