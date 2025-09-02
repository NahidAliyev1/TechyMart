using TechyMartProject.Application.DTOs.OrderDTO;

namespace TechyMartProject.Application.Services.Services;
public interface IOrderService
{
    Task<OrderSummeryDto> CreateAsync(CreateOrderDto dto);
    Task<OrderSummeryDto> PayAsync(string orderNo);
    Task CancelAsync(string orderNo);
}
