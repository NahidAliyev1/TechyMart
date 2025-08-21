using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.ProductDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _productService.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateDto dto)
        {
            var result = await _productService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
