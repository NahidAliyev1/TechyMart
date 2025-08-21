using FluentValidation;

namespace TechyMartProject.Application.DTOs.ProductDTO;
public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int CategoryId { get; set; }
}

public class ProductCreateDtoValidator : AbstractValidator<CreateProductDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required")
            .MaximumLength(255);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId is required");
    }
}