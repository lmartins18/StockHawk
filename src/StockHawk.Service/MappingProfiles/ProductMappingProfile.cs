using AutoMapper;
using StockHawk.Model;
using StockHawk.Service.DTOs;

namespace StockHawk.Service.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(src => src.Category, dest => dest.MapFrom(src => src.Category));
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, OrderItemProductDto>();
        CreateMap<UpdateProductDto, CreateProductDto>();
    }
}