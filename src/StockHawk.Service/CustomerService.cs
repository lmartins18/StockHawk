using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.Utilities;

namespace StockHawk.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> AddCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        var existingCustomer = (await _customerRepository.GetAllAsync())
           .FirstOrDefault(c => !c.IsDeleted && c.Email.Equals(createCustomerDto.Email, StringComparison.OrdinalIgnoreCase) || c.PhoneNumber == createCustomerDto.PhoneNumber);

        if (existingCustomer != null)
        {
            var messages = new List<string>();

            // Guard clauses
            if (existingCustomer.Email == createCustomerDto.Email)
                messages.Add("email address");
            if (existingCustomer.PhoneNumber == createCustomerDto.PhoneNumber)
                messages.Add("phone number");


            var duplicateProps = string.Join(" and ", messages);
            throw new DuplicateEntityException($"A customer with this {duplicateProps} already exists.");
        }

        var customer = _mapper.Map<Customer>(createCustomerDto);
        await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }
    public async Task<CustomerDto?> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
    {
        var customer = await _customerRepository.GetByIdAsync(updateCustomerDto.Id);

        if (customer is null) return null;

        // Verify if data duplicate.
        var existingCustomer = (await _customerRepository.GetAllAsync())
           .FirstOrDefault(c => !c.IsDeleted && c.Email.Equals(updateCustomerDto.Email, StringComparison.OrdinalIgnoreCase) || c.PhoneNumber == updateCustomerDto.PhoneNumber);

        if (existingCustomer != null && existingCustomer.Id != updateCustomerDto.Id)
        {
            var messages = new List<string>();

            // Guard clauses
            if (existingCustomer.Email.Equals(updateCustomerDto.Email, StringComparison.OrdinalIgnoreCase))
                messages.Add("email address");
            if (existingCustomer.PhoneNumber == updateCustomerDto.PhoneNumber)
                messages.Add("phone number");


            var duplicateProps = string.Join(" and ", messages);
            throw new DuplicateEntityException($"A customer with this {duplicateProps} already exists.");
        }
        // Apply updates from DTO to entity
        UpdateHelper.ApplyUpdates(updateCustomerDto, customer);

        await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<int?> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null) return null;

        await _customerRepository.DeleteAsync(customer);

        return id;
    }
    public async Task<int?> DeactivateCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null) return null;

        await _customerRepository.DeactivateAsync(customer);
        return id;
    }
}