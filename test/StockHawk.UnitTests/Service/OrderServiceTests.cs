using AutoMapper;
using FluentAssertions;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.MappingProfiles;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service;

public class OrderServiceTests
{
    private readonly FakeOrderRepository _orderRepository;
    private readonly FakeProductRepository _productRepository;
    private readonly FakeCustomerRepository _customerRepository;
    private readonly FakeOrderTypeRepository _orderTypeRepository;
    private readonly FakeOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public OrderServiceTests()
    {
        _orderRepository = new FakeOrderRepository();
        _productRepository = new FakeProductRepository();
        _customerRepository = new FakeCustomerRepository();
        _orderTypeRepository = new FakeOrderTypeRepository();
        _orderStatusRepository = new FakeOrderStatusRepository();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderMappingProfile>();
            cfg.AddProfile<OrderItemMappingProfile>();
            cfg.AddProfile<OrderTypeMappingProfile>();
            cfg.AddProfile<OrderStatusMappingProfile>();
        });
        _mapper = config.CreateMapper();

        _orderService = new OrderService(_orderRepository, _productRepository, _customerRepository, _orderTypeRepository, _orderStatusRepository, _mapper);
    }

    private async Task<CreateOrderDto> InitializeNewValidOrder()
    {
        // Arrange
        var customer = await _customerRepository.GetByIdAsync(2);
        var orderType = await _orderTypeRepository.GetByIdAsync(2);
        var orderStatus = await _orderStatusRepository.GetByIdAsync(2);
        var product = await _productRepository.GetByIdAsync(2);

        var createOrderDto = new CreateOrderDto
        {
            CustomerId = customer!.Id,
            Reference = "REF10",
            OrderTypeId = orderType!.Id,
            OrderStatusId = orderStatus!.Id,
            OrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto { ProductId = product!.Id, Quantity = 1}
            }
        };
        return createOrderDto;
    }

    [Fact]
    public async Task GetAllOrdersAsync_ReturnsAllOrders()
    {
        // Arrange
        var orders = _orderRepository.GetAll();
        var expectedOrders = orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();

        // Act
        var result = (await _orderService.GetAllOrdersAsync()).ToList();

        // Assert
        result.Should().HaveCount(expectedOrders.Count);
        result.Should().BeEquivalentTo(expectedOrders);
    }

    [Fact]
    public async Task GetOrderByIdAsync_ReturnsOrder()
    {
        // Arrange
        var order = _orderRepository.GetById(1);
        var expectedOrder = _mapper.Map<OrderDto>(order);

        // Act
        var result = await _orderService.GetOrderByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedOrder);
    }

    [Fact]
    public async Task AddOrderAsync_CreatesOrderSuccessfully_WhenValidData()
    {
        // Arrange
        CreateOrderDto createOrderDto = await InitializeNewValidOrder();

        // Act
        var result = await _orderService.AddOrderAsync(createOrderDto);

        // Assert
        result.Should().NotBeNull();
        result.OrderItems.Should().HaveCount(createOrderDto.OrderItems.Count);
        result.OrderItems.First().ProductId.Should().Be(createOrderDto.OrderItems.First().ProductId);
    }

    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenCustomerDoesNotExist()
    {
        // Arrange
        var createOrderDto = await InitializeNewValidOrder();
        var customerId = 999;

        // Act
        createOrderDto.CustomerId = customerId;
        Func<Task> act = async () => await _orderService.AddOrderAsync(createOrderDto);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Customer with ID {customerId} not found.");
    }

    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenOrderTypeDoesNotExist()
    {
        // Arrange
        var createOrderDto = await InitializeNewValidOrder();
        var orderTypeId = 999;

        // Act
        createOrderDto.OrderTypeId = orderTypeId;
        Func<Task> act = async () => await _orderService.AddOrderAsync(createOrderDto);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"OrderType with ID {orderTypeId} not found.");
    }

    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenOrderStatusDoesNotExist()
    {
        // Arrange
        var createOrderDto = await InitializeNewValidOrder();

        // Act
        createOrderDto.OrderStatusId = 999;
        Func<Task> act = async () => await _orderService.AddOrderAsync(createOrderDto);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"OrderStatus with ID {createOrderDto.OrderStatusId} not found.");
    }

    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = 999;
        var createOrderDto = new CreateOrderDto
        {
            CustomerId = 1,
            Reference = "REF1",
            OrderTypeId = 1,
            OrderStatusId = 1,
            OrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto { ProductId = productId, Quantity = 1}
            }
        };

        // Act
        Func<Task> act = async () => await _orderService.AddOrderAsync(createOrderDto);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Product with ID {productId} not found.");
    }

    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenDuplicateOrderMadeOnSameDay()
    {
        // Arrange
        var createOrderDto = await InitializeNewValidOrder();
        var createOrderDto2 = new CreateOrderDto
        {
            CustomerId = createOrderDto.CustomerId,
            Reference = "AnotherNewReference",
            OrderTypeId = createOrderDto.OrderTypeId,
            OrderStatusId = createOrderDto.OrderStatusId,
            OrderItems = createOrderDto.OrderItems
        };

        // Act
        Func<Task> act = async () =>
        {
            await _orderService.AddOrderAsync(createOrderDto);
            await _orderService.AddOrderAsync(createOrderDto2);
        };

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("An order for this customer has already been placed on this date.");
    }
    [Fact]
    public async Task AddOrderAsync_ShouldThrowException_WhenDuplicateReference()
    {
        // Arrange
        var existingOrderRef = (await _orderRepository.GetByIdAsync(1))!.Reference;
        var createOrderDto = new CreateOrderDto()
        {
            Reference = existingOrderRef,
            CustomerId = 1,
            OrderStatusId = 1,
            OrderTypeId = 1,
            OrderItems = [
                new CreateOrderItemDto()
                {
                    ProductId = 1,
                    Quantity = 1
                }]
        };
        // Act
        Func<Task> act = async () => await _orderService.AddOrderAsync(createOrderDto);


        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
                .WithMessage("An order with this reference already exists");
    }

    [Fact]
    public async Task DeleteOrderAsync_DeletesOrder()
    {
        // Arrange
        var order = _orderRepository.GetById(1);

        // Act
        await _orderService.DeleteOrderAsync(1);

        // Assert
        var deletedOrder = _orderRepository.GetById(1);
        deletedOrder.Should().BeNull();
    }

    [Fact]
    public async Task GetOrdersByCustomerAsync_ReturnsOrders()
    {
        // Arrange
        const int customerId = 1;
        var orders = _orderRepository.GetOrdersByCustomer(customerId);
        var expectedOrders = orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();

        // Act
        var result = (await _orderService.GetOrdersByCustomerAsync(customerId)).ToList();

        // Assert
        result.Should().HaveCount(expectedOrders.Count);
        result.Should().BeEquivalentTo(expectedOrders);
    }

    [Fact]
    public async Task UpdateOrderAsync_UpdatesOrderTotalAmount()
    {
        // Arrange
        var orderId = 1;
        var order = _orderRepository.GetById(orderId);
        var updateOrderDto = new UpdateOrderDto
        {
            Id = orderId,
            OrderStatusId = 1
        };

        // Act
        var result = await _orderService.UpdateOrderAsync(updateOrderDto);

        // Assert
        result.Should().NotBeNull();
        result!.TotalAmount.Should().Be(order!.TotalAmount);

        var updatedOrder = _orderRepository.GetById(orderId);
        updatedOrder.Should().NotBeNull();
        updatedOrder!.TotalAmount.Should().Be(order.TotalAmount);
    }

    [Fact]
    public async Task UpdateOrderAsync_ShouldReturnNull_WhenOrderNotFound()
    {
        // Arrange
        var updateOrderDto = new UpdateOrderDto
        {
            Id = 999, // Non-existing ID
            OrderStatusId = 0
        };

        // Act
        var result = await _orderService.UpdateOrderAsync(updateOrderDto);

        // Assert
        result.Should().BeNull();
    }

}
