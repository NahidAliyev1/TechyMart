using TechyMartProject.Application.DTOs.OrderDTO;
using TechyMartProject.Domain.Enums;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Application.Services.Implementations;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task CancelAsync(string orderNo)
    {
        var order = await _repo.GetByOrderNoAsync(orderNo);
        if (order is null)
        {
            throw new Exception("Sifaris tapilmadi");
        }
        if (order.Status == Status.Shipped || order.Status == Status.Paid)
        {
            throw new Exception("Sifarisi legv etmek olmaz");
        }
        order.Status = Status.Cancelled;
        await _repo.SaveChangesAsync();
    }

    public async Task<OrderSummeryDto> CreateAsync(CreateOrderDto dto)
    {
        var order = _mapper.Map<Order>(dto);
        order.OrderNo = Guid.NewGuid().ToString("N")[..10].ToUpper();
        order.Status = Status.Pending;

       await _repo.AddAsync(order);
       await _repo.SaveChangesAsync();

        return _mapper.Map<OrderSummeryDto>(order);
    }

    public async Task<OrderSummeryDto> PayAsync(string orderNo)
    {
        var order = await _repo.GetByOrderNoAsync(orderNo);
        if (order == null) throw new KeyNotFoundException("Order tapılmadı.");

        if (order.Status != Status.Pending) throw new InvalidOperationException("Order artıq ödənilib və ya ləğv olunub.");

        order.Status = Status.Paid;
        await _repo.SaveChangesAsync();

        return _mapper.Map<OrderSummeryDto>(order);
    }
}
