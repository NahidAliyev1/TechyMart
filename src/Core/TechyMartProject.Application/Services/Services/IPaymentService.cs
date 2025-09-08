using TechyMartProject.Application.DTOs.PaymentDTO;
using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Application.Services.Services;
public interface IPaymentService
{
    Task<PaymentDto> CreatePayment(CreatePaymentDto dto);
    Task UpdatePaymentStatusAsync(Status intentId, Status status);
    Task<PaymentDto?> GetPaymentByIntentId(string intentId);
    Task UpdatePaymentStatusAsync(string ıd, string v);
}
