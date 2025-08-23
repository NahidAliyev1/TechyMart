

namespace TechyMartProject.Application.Services.Services;
public interface ICategoryService
{

    Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
    Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto);
    Task<GetCategoryDto> GetByIdAsync(int id);
    Task<List<GetCategoryDto>> GetAllAsync();
    Task DeleteAsync(int id);
}
