using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Enums;
using TechyMartProject.Domain.Interfaces.Repositories.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories;
public interface IOtpRepository:IRepository<OtpCode>
{
    Task<OtpCode?> GetValidOtpAsync(string email, string code, OtpType type);
    Task MarkOtpAsUsedAsync(OtpCode otpCode);
}
