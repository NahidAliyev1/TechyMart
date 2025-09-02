using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.Persistence.Repositories;
public class OrderRepository :  Repository<Order> ,IOrderRepository
{
    private readonly TechyMartDbContext _context;

    public OrderRepository(TechyMartDbContext context):base(context)
    {
        _context = context;
    }

    public async Task  AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id==id);

    }

    public async Task<Order> GetByOrderNoAsync(string orderNo)
    {
        return await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.OrderNo == orderNo);
    }
    

    public async Task SaveChangesAsync()
    {
       await _context.SaveChangesAsync();
    }
}
