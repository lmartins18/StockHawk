using AutoMapper;
using StockHawk.Model;
using StockHawk.Service.DTOs;

namespace StockHawk.Service.MappingProfiles;

public class OrderStatusMappingProfile : Profile
{
    public OrderStatusMappingProfile()
    {
        CreateMap<OrderStatus, OrderStatusDto>();
        CreateMap<CreateOrderStatusDto, OrderStatus>();
        CreateMap<UpdateOrderStatusDto, OrderStatus>();
        CreateMap<OrderStatus, OrderOrderStatusDto>();
    }
}