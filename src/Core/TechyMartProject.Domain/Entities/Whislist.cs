namespace TechyMartProject.Domain.Entities;
public class Whislist:BaseEntity
{

    public int UserId { get; set; }
    public AppUser User { get; set; }
    public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
}
