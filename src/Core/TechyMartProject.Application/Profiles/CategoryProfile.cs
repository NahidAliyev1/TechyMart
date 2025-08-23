

namespace TechyMartProject.Application.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Domain.Entities.Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Domain.Entities.Category>().ReverseMap();
            CreateMap<GetCategoryDto, Domain.Entities.Category>().ReverseMap();
        }
    }
}
