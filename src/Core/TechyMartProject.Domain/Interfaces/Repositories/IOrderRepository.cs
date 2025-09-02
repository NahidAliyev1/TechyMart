using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories;
public interface IOrderRepository:IRepository<Order>
{
    Task<Order> GetByIdAsync(int id);
    Task<Order> GetByOrderNoAsync(string orderNo);
    Task AddAsync(Order order);
    Task  SaveChangesAsync();
}
