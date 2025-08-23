using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.CategoryDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
            public CategoryController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }
    
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
            {
                var result = await _categoryService.CreateAsync(dto);
                return Ok(result);
            }
    
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _categoryService.GetByIdAsync(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
    
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _categoryService.GetAllAsync();
                return Ok(result);
            }
    
            [HttpPut]
            public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
            {
                var result = await _categoryService.UpdateAsync(dto);
                return Ok(result);
            }
    
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _categoryService.DeleteAsync(id);
                return NoContent();
        }
    }
}
