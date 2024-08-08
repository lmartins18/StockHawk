using AutoMapper;
using StockHawk.Model;
using StockHawk.Service.DTOs;

namespace StockHawk.Service.MappingProfiles;

public class OrderTypeMappingProfile : Profile
{
    public OrderTypeMappingProfile()
    {
        CreateMap<OrderType, OrderTypeDto>();
        CreateMap<CreateOrderTypeDto, OrderType>();
        CreateMap<UpdateOrderTypeDto, OrderType>();
        CreateMap<OrderType, OrderOrderTypeDto>();
    }
}