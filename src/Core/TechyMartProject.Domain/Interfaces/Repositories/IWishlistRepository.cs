using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories
{
    public interface IWishlistRepository:IRepository<Whislist>
    {
        Task<Whislist> GetWishlistWithItemsAsync(int userId);
        Task AddItemAsync(WishlistItem item);
        Task RemoveItemAsync(int itemId);
    }
}
