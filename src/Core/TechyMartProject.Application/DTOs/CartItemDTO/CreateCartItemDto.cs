namespace TechyMartProject.Application.DTOs.CartItemDTO;
public class CreateCartItemDto
{

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
}


public class CreateCartItemDtoValidator : AbstractValidator<CreateCartItemDto>
{
    public CreateCartItemDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}
