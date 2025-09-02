namespace TechyMartProject.Application.DTOs.AddresDTO;
public class AddresDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
}
public class AddressDtoValidator : AbstractValidator<AddresDto>
{
    public AddressDtoValidator()
    {
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.Street).NotEmpty();
        RuleFor(x => x.ZipCode).NotEmpty();
    }
}