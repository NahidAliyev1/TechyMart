namespace TechyMartProject.Application.DTOs.ProductDTO;

public class ProductGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}