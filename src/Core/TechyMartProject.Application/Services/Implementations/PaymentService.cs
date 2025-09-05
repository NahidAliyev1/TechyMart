using TechyMartProject.Application.DTOs.PaymentDTO;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Application.Services.Implementations;
public class PaymentService : IPaymentService
{

    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task<PaymentDto> CreatePayment(CreatePaymentDto dto)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(dto.Amount * 100), // Stripe sentləri qəbul edir
          
            Metadata = new Dictionary<string, string> { { "orderId", dto.OrderId } }
        };

        var service = new PaymentIntentService();
        var intent = await service.CreateAsync(options);

        var payment = new Payment
        {
            OrderId = dto.OrderId,
            Amount = dto.Amount,
       
            PaymentIntentId = intent.Id,
            Status = intent.Status
        };

        await _paymentRepository.CreateAsync(payment);

        return _mapper.Map<PaymentDto>(payment);
    }

    public async Task<PaymentDto?> GetPaymentByIntentId(string intentId)
    {
        var payment = await _paymentRepository.GetByPaymentIntentIdAsync(intentId);
        return payment != null ? _mapper.Map<PaymentDto>(payment) : null;
    }

    public async Task UpdatePaymentStatusAsync(string intentId, string status)
    {

        var result=await _paymentRepository.GetByPaymentIntentIdAsync(intentId);
        if (result!= null)
        {
            result.Status = status;
             _paymentRepository.Update(result);
        }


    }
}
