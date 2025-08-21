using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Confugrations;
public class ProductConfugrations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.StockQuantity)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.ImageUrl)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(p => p.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
