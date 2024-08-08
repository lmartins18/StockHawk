using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers;

public class OrderStatusControllerTests : IntegrationTestAuthBase
{
    public OrderStatusControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateOrderStatus_ShouldReturnCreatedOrderStatus()
    {
        OrderStatusDto? createdOrderStatus = null;

        try
        {
            // Arrange
            var createOrderStatusDto = new CreateOrderStatusDto
            {
                Name = "New Status",
                Description = "New Order Status Description"
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/order-statuses", createOrderStatusDto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            createdOrderStatus = await response.Content.ReadFromJsonAsync<OrderStatusDto>();
            createdOrderStatus.Should().NotBeNull();
            createdOrderStatus!.Name.Should().Be(createOrderStatusDto.Name);
            createdOrderStatus.Description.Should().Be(createOrderStatusDto.Description);
        }
        finally
        {
            // Cleanup
            if (createdOrderStatus != null)
            {
                await DeleteOrderStatusAsync(createdOrderStatus.Id);
            }
        }
    }

    [Fact]
    public async Task GetOrderStatus_ShouldReturnOrderStatus_WhenOrderStatusExists()
    {
        OrderStatusDto? orderStatus = null;

        try
        {
            // Arrange
            orderStatus = await CreateOrderStatusAsync();

            // Act
            var response = await Client.GetAsync($"/api/order-statuses/{orderStatus.Id}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var retrievedOrderStatus = await response.Content.ReadFromJsonAsync<OrderStatusDto>();
            retrievedOrderStatus.Should().NotBeNull();
            retrievedOrderStatus!.Id.Should().Be(orderStatus.Id);
        }
        finally
        {
            // Cleanup
            if (orderStatus != null)
            {
                await DeleteOrderStatusAsync(orderStatus.Id);
            }
        }
    }

    [Fact]
    public async Task GetOrderStatus_ShouldReturnNotFound_WhenOrderStatusDoesNotExist()
    {
        // Act
        var response = await Client.GetAsync("/api/order-statuses/999");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteOrderStatus_ShouldReturnBadRequest_WhenOrderStatusHasAssociatedOrders()
    {
        OrderStatusDto? orderStatusWithOrders = null;
        List<int> orderIds = new List<int>();

        try
        {
            // Create order status with associated orders
            orderStatusWithOrders = await CreateOrderStatusWithOrdersAsync();
            orderIds = await GetOrderIdsByOrderStatusAsync(orderStatusWithOrders.Id);

            // Act
            var response = await Client.DeleteAsync($"/api/order-statuses/{orderStatusWithOrders.Id}");

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

            if (orderStatusWithOrders != null)
            {
                await DeleteOrderStatusAsync(orderStatusWithOrders.Id);
            }
        }
    }

    [Fact]
    public async Task DeleteOrderStatus_ShouldReturnNoContent_WhenOrderStatusHasNoAssociatedOrders()
    {
        OrderStatusDto? orderStatus = null;
        HttpResponseMessage? response = null;
        try
        {
            // Arrange
            orderStatus = await CreateOrderStatusAsync();

            // Act
            response = await Client.DeleteAsync($"/api/order-statuses/{orderStatus.Id}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
        finally
        {
            // Cleanup
            if (orderStatus != null && response?.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                await DeleteOrderStatusAsync(orderStatus.Id);
            }
        }
    }

    // Helper methods for setup and cleanup
    private async Task<OrderStatusDto> CreateOrderStatusAsync()
    {
        var createOrderStatusDto = new CreateOrderStatusDto
        {
            Name = "Test Status"
        };
        var response = await Client.PostAsJsonAsync("/api/order-statuses", createOrderStatusDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OrderStatusDto>() ?? throw new Exception("Failed to create order status");
    }

    private async Task<OrderStatusDto> CreateOrderStatusWithOrdersAsync()
    {
        // Create order status
        var orderStatus = await CreateOrderStatusAsync();

        // Create associated orders
        var createOrderDto = new CreateOrderDto
        {
            Reference = "ORD100",
            OrderDate = DateTime.UtcNow.AddYears(-1),
            ShippingCost = 20.00m,
            TotalAmount = 720.00m,
            CustomerId = 1,
            OrderStatusId = orderStatus.Id,
            OrderTypeId = 1,
            OrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
            }
        };
        var orderResponse = await Client.PostAsJsonAsync("/api/orders", createOrderDto);
        orderResponse.EnsureSuccessStatusCode();

        return orderStatus;
    }

    private async Task<List<int>> GetOrderIdsByOrderStatusAsync(int orderStatusId)
    {
        // Get order status to retrieve associated orders
        var response = await Client.GetAsync($"/api/order-statuses/{orderStatusId}");
        response.EnsureSuccessStatusCode();
        var orderStatus = await response.Content.ReadFromJsonAsync<OrderStatusDto>();

        // Return the IDs of orders associated with the order status
        return orderStatus?.Orders.Select(o => o.Id).ToList() ?? new List<int>();
    }

    private async Task DeleteOrderAsync(int orderId)
    {
        var response = await Client.DeleteAsync($"/api/orders/{orderId}");
        response.EnsureSuccessStatusCode();
    }

    private async Task DeleteOrderStatusAsync(int orderStatusId)
    {
        var response = await Client.DeleteAsync($"/api/order-statuses/{orderStatusId}");
        response.EnsureSuccessStatusCode();
    }
}
