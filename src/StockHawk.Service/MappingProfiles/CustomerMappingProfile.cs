using AutoMapper;
using StockHawk.Model;
using StockHawk.Service.DTOs;

namespace StockHawk.Service.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<CustomerDto, UpdateCustomerDto>();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
    }
}