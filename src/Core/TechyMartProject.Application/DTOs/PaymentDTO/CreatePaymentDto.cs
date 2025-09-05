namespace TechyMartProject.Application.DTOs.PaymentDTO;
public class CreatePaymentDto
{
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
   
}
public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
{
    public CreatePaymentDtoValidator()
    {
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("OrderId is required.")
            .NotNull().WithMessage("OrderId cannot be null.");
        RuleFor(p => p.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");
    }
}
