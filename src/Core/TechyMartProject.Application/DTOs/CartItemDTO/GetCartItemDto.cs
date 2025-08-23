namespace TechyMartProject.Application.DTOs.CartItemDTO;

public class GetCartItemDto
{
  
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; } = null!;
   
}