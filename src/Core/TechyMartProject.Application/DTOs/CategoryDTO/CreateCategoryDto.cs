

namespace TechyMartProject.Application.DTOs.CategoryDTO;
public class CreateCategoryDto
{
    public string Name { get; set; }
}


public class  CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>

{

    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Category name must be at least 3 characters long.");

    }

}
