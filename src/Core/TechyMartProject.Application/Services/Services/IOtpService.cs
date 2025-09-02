using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Application.Services.Services
{
    public interface IOtpService
    {
        Task<string> GenerateAndSendOtpAsync(string email, OtpType type);
        Task<bool> VerifyOtpAsync(string email, string code, OtpType type);
    }
}
