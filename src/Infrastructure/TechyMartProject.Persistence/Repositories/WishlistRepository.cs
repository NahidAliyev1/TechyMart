using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.Persistence.Repositories
{
    public class WishlistRepository : Repository<Whislist>, IWishlistRepository
    {

        public readonly TechyMartDbContext _techyMartDbContext;
        public WishlistRepository(TechyMartDbContext techyMartDbContext) : base(techyMartDbContext)
        {
        }

        public async Task AddItemAsync(WishlistItem item)
        {
            await _techyMartDbContext.WishlistItems.AddAsync(item);
            await _techyMartDbContext.SaveChangesAsync();
        }

        public async Task<Whislist> GetWishlistWithItemsAsync(int userId)
        {
            return await _techyMartDbContext.Wishlists
           .Include(x => x.WishlistItems)
           .ThenInclude(i => i.Product)
           .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task RemoveItemAsync(int itemId)
        {
            var item = await _techyMartDbContext.WishlistItems.FindAsync(itemId);
            if (item != null)
            {
                _techyMartDbContext.WishlistItems.Remove(item);
                await _techyMartDbContext.SaveChangesAsync();
            }
        }
    }
}
