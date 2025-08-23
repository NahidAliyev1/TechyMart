using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechyMartProject.Application.DTOs.CategoryDTO;

namespace TechyMartProject.Application.Services.Services;
public interface ICategoryService
{

    Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
    Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto);
    Task<GetCategoryDto> GetByIdAsync(int id);
    Task<List<GetCategoryDto>> GetAllAsync();
    Task DeleteAsync(int id);
}
