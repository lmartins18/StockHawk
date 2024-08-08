using AutoMapper;
using FluentAssertions;
using StockHawk.Model;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service;

public class OrderTypeServiceTests
{
    private readonly OrderTypeService _orderTypeService;
    private readonly FakeOrderTypeRepository _orderTypeRepository;
    private readonly IMapper _mapper;

    public OrderTypeServiceTests()
    {
        _orderTypeRepository = new FakeOrderTypeRepository();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderType, OrderTypeDto>();
            cfg.CreateMap<CreateOrderTypeDto, OrderType>();
            cfg.CreateMap<UpdateOrderTypeDto, OrderType>();
            cfg.CreateMap<OrderTypeDto, OrderType>();
        });
        _mapper = configuration.CreateMapper();

        _orderTypeService = new OrderTypeService(_orderTypeRepository, _mapper);
    }

    [Fact]
    public async Task GetAllOrderTypesAsync_ReturnsOrderTypeDtos()
    {
        // Act
        var repoItems = await _orderTypeRepository.GetAllAsync();
        var result = await _orderTypeService.GetAllOrderTypesAsync();

        // Assert
        result.Should().HaveCount(3); // Adjust this if the initial data count in FakeOrderTypeRepository changes
        result.Should().BeEquivalentTo(repoItems.Select(_mapper.Map<OrderTypeDto>));
    }

    [Fact]
    public async Task GetOrderTypeByIdAsync_ReturnsOrderTypeDto()
    {
        // Act
        var result = await _orderTypeService.GetOrderTypeByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Online");
    }

    [Fact]
    public async Task AddOrderTypeAsync_AddsAndReturnsOrderTypeDto()
    {
        // Arrange
        var createDto = new CreateOrderTypeDto { Name = "Subscription", Description = "Subscription-based order" };

        // Act
        var result = await _orderTypeService.AddOrderTypeAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(createDto.Name);
        result.Description.Should().Be(createDto.Description);

        // Verify the order type was added
        var addedOrderType = await _orderTypeService.GetOrderTypeByIdAsync(result.Id);
        addedOrderType.Should().NotBeNull();
        addedOrderType!.Name.Should().Be(createDto.Name);
    }
    [Fact]
    public async Task AddOrdertypeAsync_ShouldThrowDuplicateCategoryException_WhenNameIsDuplicate()
    {
        // Arrange
        var existing = await _orderTypeRepository.GetByIdAsync(1);
        var duplicate = new CreateOrderTypeDto { Name = existing!.Name, Description = "Description" };

        // Act
        Func<Task> act = async () => await _orderTypeService.AddOrderTypeAsync(duplicate);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("An order type with this name already exists.");
    }
    [Fact]
    public async Task UpdateOrderTypeAsync_ShouldThrowDuplicateEntityException_WhenOrderTypeWithSameNameExists()
    {
        // Arrange
        var existingOrderType = await _orderTypeRepository.GetByIdAsync(1);

        var updateOrderTypeDto = new UpdateOrderTypeDto
        {
            Id = 2,
            Name = existingOrderType!.Name, // Same name as an existing order type
        };

        // Act
        Func<Task> act = async () => await _orderTypeService.UpdateOrderTypeAsync(updateOrderTypeDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage($"An order type with this name already exists.");
    }

    [Fact]
    public async Task UpdateOrderTypeAsync_UpdatesOrderType()
    {
        // Arrange
        var orderTypeDto = new UpdateOrderTypeDto
        {
            Id = 1,
            Name = "UpdatedOrderType",
        };

        // Act
        var result = await _orderTypeService.UpdateOrderTypeAsync(orderTypeDto);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("UpdatedOrderType");
    }

    [Fact]
    public async Task UpdateOrderTypeAsync_ShouldReturnNull_WhenOrderTypeDoesNotExist()
    {
        // Arrange
        var updateOrderTypeDto = new UpdateOrderTypeDto
        {
            Id = 999, // Non-existent order type ID
            Name = "NonExistentOrderType",
        };

        // Act
        var result = await _orderTypeService.UpdateOrderTypeAsync(updateOrderTypeDto);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteOrderTypeAsync_DeletesOrderType()
    {
        // Act
        var result = await _orderTypeService.DeleteOrderTypeAsync(2);

        // Assert
        result.Should().BeTrue();

        // Verify the order type was deleted
        var deletedOrderType = await _orderTypeService.GetOrderTypeByIdAsync(2);
        deletedOrderType.Should().BeNull();
    }

    [Fact]
    public async Task DeleteOrderTypeAsync_ReturnsFalseIfOrdersExist()
    {
        // Arrange
        var orderType = new OrderType
        {
            Id = 4,
            Name = "Subscription",
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1, Reference = "Order1", CustomerId = 1, OrderDate = DateTime.UtcNow, ShippingCost = 10, TotalAmount = 100,
                    OrderStatusId = 1, OrderTypeId = 1,
                    Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789", Address = "123 Main St" },
                    OrderStatus= new OrderStatus { Id = 1, Name = "Pending" },
                    OrderType = new OrderType { Id = 1, Name = "Standard" },
                    OrderItems = new List<OrderItem>()
                },
            }
        };
        await _orderTypeRepository.AddAsync(orderType);

        // Act
        var result = await _orderTypeService.DeleteOrderTypeAsync(4);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteOrderTypeAsync_ReturnsNullIfNotFound()
    {
        // Act
        var result = await _orderTypeService.DeleteOrderTypeAsync(999);

        // Assert
        result.Should().BeNull();
    }
}
