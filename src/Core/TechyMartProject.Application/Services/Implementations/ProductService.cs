using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechyMartProject.Application.DTOs.ProductDTO;
using TechyMartProject.Application.Services.Services;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Application.Services.Implementations;
public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product> productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductGetDto> CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;

        await _productRepository.CreateAsync(product);

        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.FindByIdAsync(id);
        if (product == null) throw new Exception("Product not found");

        _productRepository.Delete(product);
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAll(null, "Category").ToListAsync();
        return _mapper.Map<List<ProductGetDto>>(products); 
    }

    public async Task<ProductGetDto> GetByIdAsync(int id)
    {

        var product = await _productRepository.FindByIdAsync(id, "Category");
        if (product == null) return null;

        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task<ProductGetDto> UpdateAsync(ProductUpdateDto dto)
    {
        var product = await _productRepository.FindByIdAsync(dto.Id);
        if (product == null) throw new Exception("Product not found");

        _mapper.Map(dto, product);
        product.UpdatedAt = DateTime.UtcNow;

        _productRepository.Update(product);

        return _mapper.Map<ProductGetDto>(product);
    }
}
