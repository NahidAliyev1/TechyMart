using TechyMartProject.Domain.Enums;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Application.Services.Implementations;
public class OtpService : IOtpService
{
    private readonly IOtpRepository _otpRepository;
    private readonly IMailService _mailService;

    public OtpService(IOtpRepository otpRepository, IMailService mailService)
    {
        _otpRepository = otpRepository;
        _mailService = mailService;
    }
    public async Task<string> GenerateAndSendOtpAsync(string email, OtpType type)
    {
        var otpCode = new Random().Next(100000, 999999).ToString();

        OtpCode otp = new OtpCode
        {
            Email = email,
            Code = otpCode,
            ExpireAt = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false,
            Type = type
        };

        await _otpRepository.CreateAsync(otp);
        await _otpRepository.SaveChangesAsync();

        string subject = type == OtpType.Register
            ? "Zeducat Qeydiyyat Doğrulama Kodu"
            : "Zeducat Şifrə Sıfırlama Kodu";

        string body = $"Salam,\n\nSizin təsdiq kodunuz: {otpCode}\n\nKod 5 dəqiqə ərzində etibarlıdır.";

        await _mailService.SendEmailAsync(email, subject, body);

        return otpCode;
    }

    public async Task<bool> VerifyOtpAsync(string email, string code, OtpType type)
    {
        OtpCode? otp = await _otpRepository.GetValidOtpAsync(email, code, type);

        if (otp == null)
            return false;

        await _otpRepository.MarkOtpAsUsedAsync(otp);

        return true;
    }
}
