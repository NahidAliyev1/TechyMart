

namespace TechyMartProject.Application.Services.Implementations;
public class CategoryService : ICategoryService
{

    private readonly IRepository<Category> _repository;

    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository,IMapper mapper)
    {
        _repository =repository;
        _mapper = mapper;
    }
    public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
    {
      var category = _mapper.Map<Category>(dto);
        await _repository.CreateAsync(category);
        return _mapper.Map<GetCategoryDto>(category);
    }

    public async Task DeleteAsync(int id)
    {
      var result = await _repository.FindByIdAsync(id);
        if (result == null) throw new Exception("Category not found");
        _repository.Delete(result);
        await Task.CompletedTask; 
    }

    public Task<List<GetCategoryDto>> GetAllAsync()
    {
       
        var categories = _repository.GetAll(null, "Products").ToListAsync();
        return categories.ContinueWith(task => _mapper.Map<List<GetCategoryDto>>(task.Result));
    }

    public async Task<GetCategoryDto> GetByIdAsync(int id)
    {
      var category = await _repository.FindByIdAsync(id, "Products");
        if (category == null) return null;
        return _mapper.Map<GetCategoryDto>(category);
    }

    public Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto)
    {
       var category = _repository.FindByIdAsync(dto.Id);
        if (category == null) throw new Exception("Category not found");
        _mapper.Map(dto, category.Result);
        _repository.Update(category.Result);
        return Task.FromResult(_mapper.Map<GetCategoryDto>(category.Result));
    }
}
