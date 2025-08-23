using FluentValidation;

namespace TechyMartProject.Application.DTOs.CategoryDTO;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.")
            .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.");
    }
}