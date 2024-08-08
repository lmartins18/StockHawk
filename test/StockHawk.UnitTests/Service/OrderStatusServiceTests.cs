using AutoMapper;
using FluentAssertions;
using StockHawk.Model;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service;

public class OrderStatusServiceTests
{
    private readonly OrderStatusService _orderStatusService;
    private readonly FakeOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderStatusServiceTests()
    {
        _orderStatusRepository = new FakeOrderStatusRepository();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderStatus, OrderStatusDto>();
            cfg.CreateMap<CreateOrderStatusDto, OrderStatus>();
            cfg.CreateMap<UpdateOrderStatusDto, OrderStatus>();
            cfg.CreateMap<OrderStatusDto, OrderStatus>();
        });
        _mapper = configuration.CreateMapper();

        _orderStatusService = new OrderStatusService(_orderStatusRepository, _mapper);
    }

    [Fact]
    public async Task GetAllOrderStatusesAsync_ReturnsOrderStatusDtos()
    {
        // Act
        var expected = await _orderStatusRepository.GetAllAsync();
        var result = await _orderStatusService.GetAllOrderStatusesAsync();

        // Assert
        result.Should().HaveCount(expected!.Count());
        result.Should().BeEquivalentTo(expected.Select(_mapper.Map<OrderStatusDto>));
    }

    [Fact]
    public async Task GetOrderStatusByIdAsync_ReturnsOrderStatusDto()
    {
        // Arrange
        var orderStatus = new OrderStatus { Id = 1, Name = "Pending" };
        await _orderStatusRepository.AddAsync(orderStatus);

        // Act
        var result = await _orderStatusService.GetOrderStatusByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Pending");
    }

    [Fact]
    public async Task AddOrderStatusAsync_AddsAndReturnsOrderStatusDto()
    {
        // Arrange
        var createDto = new CreateOrderStatusDto { Name = "Delivered" };

        // Act
        var result = await _orderStatusService.AddOrderStatusAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(createDto.Name);

        // Verify the order status was added
        var addedOrderStatus = await _orderStatusService.GetOrderStatusByIdAsync(result.Id);
        addedOrderStatus.Should().NotBeNull();
        addedOrderStatus!.Name.Should().Be(createDto.Name);
    }
    [Fact]
    public async Task AddOrderStatusAsync_ShouldThrowDuplicateCategoryException_WhenNameIsDuplicate()
    {
        // Arrange
        var existing = await _orderStatusRepository.GetByIdAsync(1);
        var duplicate = new CreateOrderStatusDto { Name = existing!.Name, Description = "Description" };

        // Act
        Func<Task> act = async () => await _orderStatusService.AddOrderStatusAsync(duplicate);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("An order status with this name already exists.");
    }


    [Fact]
    public async Task AddOrderStatusAsync_ShouldThrowDuplicateEntityException_WhenOrderStatusWithSameNameExists()
    {
        // Arrange
        var existingOrderStatus = await _orderStatusRepository.GetByIdAsync(1);

        var createOrderStatusDto = new CreateOrderStatusDto
        {
            Name = existingOrderStatus!.Name, // Same name as an existing order status
        };

        // Act
        Func<Task> act = async () => await _orderStatusService.AddOrderStatusAsync(createOrderStatusDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage($"An order status with this name already exists.");
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_ShouldThrowDuplicateEntityException_WhenOrderStatusWithSameNameExists()
    {
        // Arrange
        var existingOrderStatus = await _orderStatusRepository.GetByIdAsync(1);

        var updateOrderStatusDto = new UpdateOrderStatusDto
        {
            Id = 2,
            Name = existingOrderStatus!.Name, // Same name as an existing order status
        };

        // Act
        Func<Task> act = async () => await _orderStatusService.UpdateOrderStatusAsync(updateOrderStatusDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage($"An order status with this name already exists");
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_UpdatesOrderStatus()
    {
        // Arrange
        var orderStatusDto = new UpdateOrderStatusDto
        {
            Id = 1,
            Name = "UpdatedOrderStatus",
        };

        // Act
        var result = await _orderStatusService.UpdateOrderStatusAsync(orderStatusDto);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("UpdatedOrderStatus");
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_ShouldReturnNull_WhenOrderStatusDoesNotExist()
    {
        // Arrange
        var updateOrderStatusDto = new UpdateOrderStatusDto
        {
            Id = 999, // Non-existent order status ID
            Name = "NonExistentOrderStatus",
        };

        // Act
        var result = await _orderStatusService.UpdateOrderStatusAsync(updateOrderStatusDto);

        // Assert
        result.Should().BeNull();
    }
    [Fact]
    public async Task DeleteOrderStatusAsync_DeletesOrderStatus()
    {
        // Act
        var result = await _orderStatusService.DeleteOrderStatusAsync(2);

        // Assert
        result.Should().BeTrue();

        var deletedOrderStatus = await _orderStatusService.GetOrderStatusByIdAsync(2);
        deletedOrderStatus.Should().BeNull();
    }

    [Fact]
    public async Task DeleteOrderStatusAsync_ReturnsFalseIfOrdersExist()
    {
        // Arrange
        var orderStatus = new OrderStatus
        {
            Id = 10,
            Name = "Shipped",
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1, Reference = "Order1", CustomerId = 1, OrderDate = DateTime.UtcNow, ShippingCost = 10, TotalAmount = 100,
                    OrderStatusId = 1, OrderTypeId = 1,
                    Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789", Address = "123 Main St" },
                    OrderStatus = new OrderStatus { Id = 1, Name = "Pending" },
                    OrderType = new OrderType { Id = 1, Name = "Standard" },
                    OrderItems = new List<OrderItem>()
                },
            }
        };
        await _orderStatusRepository.AddAsync(orderStatus);

        // Act
        var result = await _orderStatusService.DeleteOrderStatusAsync(orderStatus.Id);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteOrderStatusAsync_ReturnsFalseIfNotFound()
    {
        // Act
        var result = await _orderStatusService.DeleteOrderStatusAsync(999);

        // Assert
        result.Should().BeNull();
    }
}
