using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories;
public interface IPaymentRepository:IRepository<Payment>
{

    Task<Payment?> GetByPaymentIntentIdAsync(string intentId);
}
