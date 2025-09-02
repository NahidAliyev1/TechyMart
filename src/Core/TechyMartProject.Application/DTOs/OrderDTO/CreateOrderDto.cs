using TechyMartProject.Application.DTOs.AddresDTO;
using TechyMartProject.Application.DTOs.OrderItemDto;

namespace TechyMartProject.Application.DTOs.OrderDTO;
public class CreateOrderDto
{
    public string CustomerId { get; set; }
    public AddresDto ShippingAddres { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();

}
public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId boş ola bilməz.");
        RuleFor(x => x.ShippingAddres).NotNull().SetValidator(new AddressDtoValidator());
        RuleFor(x => x.Items).NotEmpty().WithMessage("Sifarişdə ən az 1 məhsul olmalıdır.");
        RuleForEach(x => x.Items).SetValidator(new CreateOrderItemDtoValidator());
    }
}