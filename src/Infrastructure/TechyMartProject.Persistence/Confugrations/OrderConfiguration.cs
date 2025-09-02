using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Confugrations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderNo).IsRequired().HasMaxLength(20);
        builder.HasIndex(x => x.OrderNo).IsUnique();

        builder.OwnsOne(x => x.ShippingAddress, a =>
        {
            a.Property(p => p.Country).HasMaxLength(50);
            a.Property(p => p.City).HasMaxLength(50);
            a.Property(p => p.Street).HasMaxLength(200);
            a.Property(p => p.ZipCode).HasMaxLength(20);
        });

        builder.HasMany(x => x.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
