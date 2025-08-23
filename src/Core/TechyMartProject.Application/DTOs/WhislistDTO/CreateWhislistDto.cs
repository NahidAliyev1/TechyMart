namespace TechyMartProject.Application.DTOs.WhislistDTO;
public class CreateWhislistDto
{
    
    public int UserId { get; set; }
}
public class WishlistItemCreateDto
{
    public int WishlistId { get; set; }
    public int ProductId { get; set; }
}

public class WishlistItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
}

public class WishlistDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<WishlistItemDto> Items { get; set; }
}
public class WishlistCreateDtoValidator : AbstractValidator<CreateWhislistDto>
{
    public WishlistCreateDtoValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}

public class WishlistItemCreateDtoValidator : AbstractValidator<WishlistItemCreateDto>
{
    public WishlistItemCreateDtoValidator()
    {
        RuleFor(x => x.WishlistId).GreaterThan(0);
        RuleFor(x => x.ProductId).GreaterThan(0);
    }
}