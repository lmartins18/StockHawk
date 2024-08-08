using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    Task<CustomerDto> AddCustomerAsync(CreateCustomerDto createCustomerDto);
    Task<CustomerDto?> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
    Task<int?> DeleteCustomerAsync(int id);
    Task<int?> DeactivateCustomerAsync(int id);
}