using TechyMartProject.Application.DTOs.ProductDTO;

namespace TechyMartProject.Application.Services.Services;

public interface IProductService
{
    Task<ProductGetDto> CreateAsync(CreateProductDto dto);
    Task<ProductGetDto> UpdateAsync(ProductUpdateDto dto);
    Task<ProductGetDto> GetByIdAsync(int id);
    Task<List<ProductGetDto>> GetAllAsync();
    Task DeleteAsync(int id);
}
