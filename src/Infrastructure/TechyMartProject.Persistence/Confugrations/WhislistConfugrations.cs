using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Persistence.Confugrations
{
    public class WhislistConfugrations : IEntityTypeConfiguration<Whislist>
    {
        public void Configure(EntityTypeBuilder<Whislist> builder)
        {
            
        }
    }
}
