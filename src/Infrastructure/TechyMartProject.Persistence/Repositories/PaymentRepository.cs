using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.Persistence.Repositories;
public class PaymentRepository : Repository<Payment>, IPaymentRepository
{

    private readonly TechyMartDbContext _techyMartDbContext;

    public PaymentRepository(TechyMartDbContext techyMartDbContext):base(techyMartDbContext)
    {
        _techyMartDbContext = techyMartDbContext;
    }

    public async Task<Payment?> GetByPaymentIntentIdAsync(string intentId)
    {
       return await _techyMartDbContext.Payments.FirstOrDefaultAsync(p => p.PaymentIntentId == intentId);
    }
}
