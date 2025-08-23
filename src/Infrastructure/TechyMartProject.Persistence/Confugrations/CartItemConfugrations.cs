using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Confugrations
{
    public class CartItemConfugrations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
           
        }
    }
}
