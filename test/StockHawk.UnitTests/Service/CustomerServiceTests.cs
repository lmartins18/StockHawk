using AutoMapper;
using FluentAssertions;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.MappingProfiles;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service;

public class CustomerServiceTests
{
    private readonly CustomerService _customerService;
    private readonly FakeCustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerServiceTests()
    {
        _customerRepository = new FakeCustomerRepository();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerMappingProfile>();
        });
        _mapper = config.CreateMapper();

        _customerService = new CustomerService(_customerRepository, _mapper);
    }

    [Fact]
    public async Task GetAllCustomersAsync_ReturnsAllCustomers()
    {
        // Arrange
        var expectedCustomers = _customerRepository.GetAll().Select(c => _mapper.Map<CustomerDto>(c));

        // Act
        var result = await _customerService.GetAllCustomersAsync();

        // Assert
        result.Should().BeEquivalentTo(expectedCustomers, options => options.ComparingByMembers<CustomerDto>());
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ReturnsCustomer()
    {
        // Arrange
        var customerId = 1;
        var customer = _customerRepository.GetById(customerId);
        var expected = _mapper.Map<CustomerDto>(customer);

        // Act
        var result = await _customerService.GetCustomerByIdAsync(customerId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<CustomerDto>());
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ReturnsNullWhenCustomerNotFound()
    {
        // Arrange
        var nonExistentCustomerId = 99;

        // Act
        var result = await _customerService.GetCustomerByIdAsync(nonExistentCustomerId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddCustomerAsync_AddsCustomer()
    {
        // Arrange
        var newCustomerDto = new CreateCustomerDto
        {
            FirstName = "New",
            LastName = "Customer",
            Email = "newcustomer@example.com",
            PhoneNumber = "123-456-7890",
            Address = "123 New St."
        };

        var initialCount = _customerRepository.Count;
        var addedCustomerDto = await _customerService.AddCustomerAsync(newCustomerDto);

        // Act
        var customers = await _customerService.GetAllCustomersAsync();
        var addedCustomer = await _customerService.GetCustomerByIdAsync(addedCustomerDto.Id);

        // Assert
        addedCustomerDto.Should().NotBeNull();
        addedCustomer.Should().NotBeNull();
        customers.Should().HaveCount(initialCount + 1);
        addedCustomer.Should().BeEquivalentTo(newCustomerDto, options => options.ComparingByMembers<CustomerDto>());
    }

    [Fact]
    public async Task AddCustomerAsync_ShouldThrowDuplicateCustomerException_WhenBothEmailAndPhoneNumberAreDuplicate()
    {
        // Arrange
        var existingCustomer = _mapper.Map<CreateCustomerDto>(await _customerRepository.GetByIdAsync(1));

        // Act
        Func<Task> act = async () => await _customerService.AddCustomerAsync(existingCustomer);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A customer with this email address and phone number already exists.");
    }

    [Fact]
    public async Task AddCustomerAsync_ShouldThrowDuplicateCustomerException_WhenEmailIsDuplicate()
    {
        // Arrange
        var existingCustomer = _mapper.Map<CreateCustomerDto>(await _customerRepository.GetByIdAsync(1));
        existingCustomer.PhoneNumber = "123123123"; // Change phone number

        // Act
        Func<Task> act = async () => await _customerService.AddCustomerAsync(existingCustomer);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A customer with this email address already exists.");
    }

    [Fact]
    public async Task AddCustomerAsync_ShouldThrowDuplicateCustomerException_WhenPhoneNumberIsDuplicate()
    {
        // Arrange
        var existingCustomer = _mapper.Map<CreateCustomerDto>(await _customerRepository.GetByIdAsync(1));
        existingCustomer.Email = "new@mail.com";

        // Act
        Func<Task> act = async () => await _customerService.AddCustomerAsync(existingCustomer);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A customer with this phone number already exists.");
    }

    [Fact]
    public async Task UpdateCustomerAsync_UpdatesCustomer()
    {
        // Arrange
        var existingCustomer = _customerRepository.GetById(1);
        var updateCustomerDto = new UpdateCustomerDto
        {
            Id = 1,
            FirstName = "Updated",
            LastName = "Customer",
            Email = "updatedcustomer@example.com",
            PhoneNumber = "098-765-4321",
            Address = "321 Updated St."
        };

        // Act
        await _customerService.UpdateCustomerAsync(updateCustomerDto);
        var result = await _customerService.GetCustomerByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(updateCustomerDto, options => options.ComparingByMembers<CustomerDto>());
    }

    [Fact]
    public async Task UpdateCustomerAsync_NonExistentCustomer_ShouldHandleGracefully()
    {
        // Arrange
        var updateCustomerDto = new UpdateCustomerDto
        {
            Id = 99,
            FirstName = "Updated",
            LastName = "Customer",
            Email = "updatedcustomer@example.com",
            PhoneNumber = "098-765-4321",
            Address = "321 Updated St."
        };

        // Act
        await _customerService.UpdateCustomerAsync(updateCustomerDto);
        var result = await _customerService.GetCustomerByIdAsync(99);

        // Assert
        result.Should().BeNull();
    }
    [Fact]
    public async Task UpdateCustomerAsync_ShouldThrowDuplicateEntityException_WhenCustomerWithSameEmailOrPhoneExists()
    {
        // Arrange
        var customer = await _customerRepository.GetByIdAsync(1);
        var anotherCustomer = await _customerRepository.GetByIdAsync(2);

        var updateCustomerDto = new UpdateCustomerDto
        {
            Id = customer!.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = anotherCustomer!.Email, // Duplicate email
            PhoneNumber = "111123123" // New phone number
        };

        // Act
        Func<Task> act = async () => await _customerService.UpdateCustomerAsync(updateCustomerDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A customer with this email address already exists.");
    }

    [Fact]
    public async Task UpdateCustomerAsync_ShouldNotThrowException_WhenUpdatingCustomerWithUniqueDetails()
    {
        // Arrange
        var customer = await _customerRepository.GetByIdAsync(1);

        var updateCustomerDto = new UpdateCustomerDto
        {
            Id = customer!.Id,
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            Email = "newuniqueemail@example.com",
            PhoneNumber = "1113332222"
        };

        // Act
        Func<Task> act = async () => await _customerService.UpdateCustomerAsync(updateCustomerDto);

        // Assert
        await act.Should().NotThrowAsync<DuplicateEntityException>();

        var updatedCustomer = await _customerService.GetCustomerByIdAsync(customer.Id);
        updatedCustomer.Should().NotBeNull();
        updatedCustomer!.FirstName.Should().Be(updateCustomerDto.FirstName);
        updatedCustomer.LastName.Should().Be(updateCustomerDto.LastName);
        updatedCustomer.Email.Should().Be(updateCustomerDto.Email);
        updatedCustomer.PhoneNumber.Should().Be(updateCustomerDto.PhoneNumber);
    }
    [Fact]
    public async Task DeleteCustomerAsync_DeletesCustomer()
    {
        // Arrange
        var customerId = 1;
        var initialCount = _customerRepository.Count;

        // Act
        await _customerService.DeleteCustomerAsync(customerId);
        var customers = await _customerService.GetAllCustomersAsync();

        // Assert
        customers.Should().HaveCount(initialCount - 1);
        (await _customerService.GetCustomerByIdAsync(customerId)).Should().BeNull();
    }

    [Fact]
    public async Task DeleteCustomerAsync_NonExistentCustomer_ShouldHandleGracefully()
    {
        // Arrange
        var nonExistentCustomerId = 99;

        // Act
        await _customerService.DeleteCustomerAsync(nonExistentCustomerId);
        var customers = await _customerService.GetAllCustomersAsync();

        // Assert
        customers.Should().HaveCount(_customerRepository.Count); // No customer should have been deleted
    }
}
