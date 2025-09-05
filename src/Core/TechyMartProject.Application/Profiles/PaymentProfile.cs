using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using TechyMartProject.Application.DTOs.PaymentDTO;

namespace TechyMartProject.Application.Profiles;
public class PaymentProfile:Profile
{

    public PaymentProfile()
    {
        CreateMap<CreatePaymentDto, Payment>();
        CreateMap<Payment, PaymentDto>();
    }
}
