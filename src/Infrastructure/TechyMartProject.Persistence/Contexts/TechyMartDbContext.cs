using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Contexts;

public class TechyMartDbContext:IdentityDbContext<AppUser>
{
   
    public TechyMartDbContext(DbContextOptions<TechyMartDbContext> option):base(option)
    {


       
    }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<WishlistItem> WishlistItems { get; set; }
    public DbSet<Whislist> Wishlists { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OtpCode> OtpCodes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        builder.Entity<AppUser>(entity =>
        {
            entity.Property(e => e.Fullname).IsRequired().HasMaxLength(50);
          
        });

    }
    
}
