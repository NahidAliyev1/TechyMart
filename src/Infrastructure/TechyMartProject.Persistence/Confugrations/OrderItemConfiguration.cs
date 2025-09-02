using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Confugrations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductName).HasMaxLength(200);
        builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
    }
}