using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers;

public class OrderTypeControllerTests : IntegrationTestAuthBase
{
    public OrderTypeControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateOrderType_ShouldReturnCreatedOrderType()
    {
        OrderTypeDto? createdOrderType = null;

        try
        {
            // Arrange
            var createOrderTypeDto = new CreateOrderTypeDto
            {
                Name = "New Order Type"
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/order-types", createOrderTypeDto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            createdOrderType = await response.Content.ReadFromJsonAsync<OrderTypeDto>();
            createdOrderType.Should().NotBeNull();
            createdOrderType!.Name.Should().Be(createOrderTypeDto.Name);
        }
        finally
        {
            // Cleanup
            if (createdOrderType != null)
            {
                await DeleteOrderTypeAsync(createdOrderType.Id);
            }
        }
    }

    [Fact]
    public async Task GetOrderType_ShouldReturnOrderType_WhenOrderTypeExists()
    {
        OrderTypeDto? orderType = null;

        try
        {
            // Arrange
            orderType = await CreateOrderTypeAsync();

            // Act
            var response = await Client.GetAsync($"/api/order-types/{orderType.Id}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var retrievedOrderType = await response.Content.ReadFromJsonAsync<OrderTypeDto>();
            retrievedOrderType.Should().NotBeNull();
            retrievedOrderType!.Id.Should().Be(orderType.Id);
        }
        finally
        {
            // Cleanup
            if (orderType != null)
            {
                await DeleteOrderTypeAsync(orderType.Id);
            }
        }
    }

    [Fact]
    public async Task GetOrderType_ShouldReturnNotFound_WhenOrderTypeDoesNotExist()
    {
        // Act
        var response = await Client.GetAsync("/api/order-types/999");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteOrderType_ShouldReturnBadRequest_WhenOrderTypeHasAssociatedOrders()
    {
        OrderTypeDto? orderTypeWithOrders = null;
        List<int> orderIds = new List<int>();

        try
        {
            // Create order type with associated orders
            orderTypeWithOrders = await CreateOrderTypeWithOrdersAsync();
            orderIds = await GetOrderIdsByOrderTypeAsync(orderTypeWithOrders.Id);

            // Act
            var response = await Client.DeleteAsync($"/api/order-types/{orderTypeWithOrders.Id}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
        finally
        {
            // Cleanup
            foreach (var orderId in orderIds)
            {
                await DeleteOrderAsync(orderId);
            }

            if (orderTypeWithOrders != null)
            {
                await DeleteOrderTypeAsync(orderTypeWithOrders.Id);
            }
        }
    }

    [Fact]
    public async Task DeleteOrderType_ShouldReturnNoContent_WhenOrderTypeHasNoAssociatedOrders()
    {
        OrderTypeDto? orderType = null;
        HttpResponseMessage? response = null;
        try
        {
            // Arrange
            orderType = await CreateOrderTypeAsync();

            // Act
            response = await Client.DeleteAsync($"/api/order-types/{orderType.Id}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
        finally
        {
            // Cleanup
            if (orderType != null && response?.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                await DeleteOrderTypeAsync(orderType.Id);
            }
        }
    }

    // Helper methods for setup and cleanup
    private async Task<OrderTypeDto> CreateOrderTypeAsync()
    {
        var createOrderTypeDto = new CreateOrderTypeDto
        {
            Name = "Test Order Type"
        };
        var response = await Client.PostAsJsonAsync("/api/order-types", createOrderTypeDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OrderTypeDto>() ?? throw new Exception("Failed to create order type");
    }

    private async Task<OrderTypeDto> CreateOrderTypeWithOrdersAsync()
    {
        // Create order type
        var orderType = await CreateOrderTypeAsync();

        // Create associated orders
        var createOrderDto = new CreateOrderDto
        {
            Reference = "ORD100",
            OrderDate = DateTime.UtcNow.AddYears(-1),
            ShippingCost = 20.00m,
            TotalAmount = 720.00m,
            CustomerId = 1,
            OrderStatusId = 1,
            OrderTypeId = orderType.Id,
            OrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
            }
        };
        var orderResponse = await Client.PostAsJsonAsync("/api/orders", createOrderDto);
        orderResponse.EnsureSuccessStatusCode();

        return orderType;
    }

    private async Task<List<int>> GetOrderIdsByOrderTypeAsync(int orderTypeId)
    {
        // Get order type to retrieve associated orders
        var response = await Client.GetAsync($"/api/order-types/{orderTypeId}");
        response.EnsureSuccessStatusCode();
        var orderType = await response.Content.ReadFromJsonAsync<OrderTypeDto>();

        // Return the IDs of orders associated with the order type
        return orderType?.Orders.Select(o => o.Id).ToList() ?? new List<int>();
    }

    private async Task DeleteOrderAsync(int orderId)
    {
        var response = await Client.DeleteAsync($"/api/orders/{orderId}");
        response.EnsureSuccessStatusCode();
    }

    private async Task DeleteOrderTypeAsync(int orderTypeId)
    {
        var response = await Client.DeleteAsync($"/api/order-types/{orderTypeId}");
        response.EnsureSuccessStatusCode();
    }
}
