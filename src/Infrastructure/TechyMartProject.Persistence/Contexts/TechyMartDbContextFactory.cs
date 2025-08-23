using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TechyMartProject.Persistence.Contexts
{
    public class TechyMartDbContextFactory : IDesignTimeDbContextFactory<TechyMartDbContext>
    {
        public TechyMartDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TechyMartDbContext>();
            optionsBuilder.UseSqlServer("Server=WINDOWS-AEJTJIB;Database=TechyMartDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new TechyMartDbContext(optionsBuilder.Options);
        }
    }
}
