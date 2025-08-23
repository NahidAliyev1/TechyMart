

namespace TechyMartProject.Application.DTOs.ProductDTO;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int CategoryId { get; set; }
}

public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
       .GreaterThan(0).WithMessage("Product ID is required");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative");
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required")
            .MaximumLength(255).WithMessage("Image URL cannot exceed 255 characters");
        RuleFor(x => x.CategoryId)
             .GreaterThan(0).WithMessage("CategoryId is required");

    }
}