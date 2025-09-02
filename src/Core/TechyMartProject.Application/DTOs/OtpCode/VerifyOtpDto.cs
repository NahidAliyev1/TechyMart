using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Application.DTOs.OtpCode;
public class VerifyOtpDto
{
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
    public OtpType Type { get; set; }
}
public class VerifyOtpDtoValidator : AbstractValidator<VerifyOtpDto>

{
    public VerifyOtpDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz")
            .EmailAddress().WithMessage("Email formatı düzgün deyil");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod boş ola bilməz")
            .Length(6).WithMessage("Kod 6 rəqəmdən ibarət olmalıdır");
    }
}
