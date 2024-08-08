using AutoMapper;
using StockHawk.Model;
using StockHawk.Service.DTOs;

namespace StockHawk.Service.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.CustomerName,
                src => src.MapFrom(o => $"{o.Customer.FirstName} {o.Customer.LastName}"))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(o => o.OrderStatus))
            .ReverseMap();

        CreateMap<Order, SubOrderDto>();
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<UpdateOrderDto, OrderItem>().ReverseMap();
    }
}