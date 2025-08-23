namespace TechyMartProject.Domain.Entities;
public class CartItem:BaseEntity
{

    public string UserID { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    //Navigation properties
    public Product Product { get; set; } 
    public AppUser User { get; set; }
}
