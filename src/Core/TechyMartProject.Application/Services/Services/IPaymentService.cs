using TechyMartProject.Application.DTOs.PaymentDTO;

namespace TechyMartProject.Application.Services.Services;
public interface IPaymentService
{
    Task<PaymentDto> CreatePayment(CreatePaymentDto dto);
    Task UpdatePaymentStatusAsync(string intentId, string status);
    Task<PaymentDto?> GetPaymentByIntentId(string intentId);

}
