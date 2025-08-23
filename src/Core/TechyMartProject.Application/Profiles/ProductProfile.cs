

namespace TechyMartProject.Application.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductGetDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
