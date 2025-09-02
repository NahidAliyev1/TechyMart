using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechyMartProject.Application.DTOs.AddresDTO;
using TechyMartProject.Application.DTOs.OrderDTO;
using TechyMartProject.Application.DTOs.OrderItemDto;

namespace TechyMartProject.Application.Profiles;
public class OrderMappingProfile:Profile
{

    public OrderMappingProfile()
    {
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddres));

        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<AddresDto, Address>();
        CreateMap<Order, OrderSummeryDto>()
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Items.Sum(i => i.LineTotal)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
