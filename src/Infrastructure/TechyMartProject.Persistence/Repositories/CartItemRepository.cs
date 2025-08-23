using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.Persistence.Repositories;
public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    private readonly TechyMartDbContext _techyMartDbContext;
    public CartItemRepository(TechyMartDbContext techyMartDbContext) : base(techyMartDbContext)
    {
        _techyMartDbContext = techyMartDbContext;
    }

    public async Task<List<CartItem>> GetCartByUserIdAsync(string userId)
    {
        return await _techyMartDbContext.CartItems
             .Where(ci => ci.UserID == userId)
             .Include(ci => ci.Product)
             .ToListAsync();
    }
}
