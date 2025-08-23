namespace TechyMartProject.Domain.Entities;

public class WishlistItem:BaseEntity
{
   
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int WishlistId { get; set; }
    public Whislist Wishlist { get; set; }
}