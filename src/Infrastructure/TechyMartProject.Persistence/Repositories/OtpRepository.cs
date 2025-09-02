using Microsoft.EntityFrameworkCore;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Enums;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.Persistence.Repositories;
public class OtpRepository : Repository<OtpCode>, IOtpRepository
{
    private readonly TechyMartDbContext _context;

    public OtpRepository(TechyMartDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<OtpCode?> GetValidOtpAsync(string email, string code, OtpType type)
    {
        return await _context.OtpCodes.FirstOrDefaultAsync(o =>
               o.Email == email &&
               o.Code == code &&
               !o.IsUsed &&
               o.Type == type &&
               o.ExpireAt > DateTime.UtcNow);
    }

    public async Task MarkOtpAsUsedAsync(OtpCode otpCode)
    {
        otpCode.IsUsed = true;
        _context.OtpCodes.Update(otpCode);
        await _context.SaveChangesAsync();
    }
}
