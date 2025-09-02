
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using TechyMartProject.Application.Settings;

namespace TechyMartProject.Application.Services.Implementations;
public class MailService : IMailService
{
    private readonly MailSettings _settings;

    public MailService(IOptions<MailSettings> settings)
    {
        _settings = settings.Value;
    }
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var mail = new MailMessage
        {
            From = new MailAddress(_settings.Mail, _settings.DisplayName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mail.To.Add(toEmail);

        using var smtp = new SmtpClient(_settings.Host, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Mail, _settings.Password),
            EnableSsl = true
        };

        await smtp.SendMailAsync(mail);
    }
}
