using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechyMartProject.Application.DTOs.CategoryDTO;

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
