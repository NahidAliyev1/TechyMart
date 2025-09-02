

using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Application.Services.Services
{
    public interface IAuthService
    {

        Task<string> Registerasync(RegisterDto dto);
        Task<string> Loginasync(LoginDto dto);
        Task<bool> VerifyOtpAsync(string email, string code, OtpType type);
    }
}
