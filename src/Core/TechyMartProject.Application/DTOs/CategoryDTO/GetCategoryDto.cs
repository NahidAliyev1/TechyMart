namespace TechyMartProject.Application.DTOs.CategoryDTO;

public class GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<string> Products { get; set; } = new List<string>();
}