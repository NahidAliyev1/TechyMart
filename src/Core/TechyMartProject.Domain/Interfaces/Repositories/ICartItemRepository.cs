using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories;
public interface ICartItemRepository:IRepository<CartItem>
{
    Task<List<CartItem>> GetCartByUserIdAsync(string userId);
}
