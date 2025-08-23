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
