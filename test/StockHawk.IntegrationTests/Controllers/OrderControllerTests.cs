using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers
{
    public class OrderControllerTests : IntegrationTestAuthBase
    {
        public OrderControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetAllOrdersAsync_ReturnsAllOrders()
        {
            // Act
            var response = await Client.GetAsync("/api/orders");
            response.EnsureSuccessStatusCode();

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("ORD001");
            responseString.Should().Contain("ORD002");
        }

        [Fact]
        public async Task GetOrderByIdAsync_ReturnsOrder_WhenOrderExists()
        {
            OrderDto? createdOrder = null;

            try
            {
                // Arrange
                createdOrder = await CreateOrderAsync();

                // Act
                var response = await Client.GetAsync($"/api/orders/{createdOrder.Id}");
                response.EnsureSuccessStatusCode();

                // Assert
                var responseOrder = await response.Content.ReadFromJsonAsync<OrderDto>();
                responseOrder.Should().NotBeNull();
                responseOrder?.Reference.Should().Be("ORD100");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdOrder != null)
                {
                    await DeleteOrderAsync(createdOrder.Id);
                }
            }
        }

        [Fact]
        public async Task GetOrderByIdAsync_ReturnsNotFound_WhenOrderDoesNotExist()
        {
            // Act
            var response = await Client.GetAsync("/api/orders/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateOrderAsync_ReturnsCreatedOrder()
        {
            OrderDto? createdOrder = null;

            try
            {
                // Arrange & Act
                createdOrder = await CreateOrderAsync();

                // Assert
                createdOrder.Should().NotBeNull();
                createdOrder?.Reference.Should().Be("ORD100");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdOrder != null)
                {
                    await DeleteOrderAsync(createdOrder.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateOrderAsync_ReturnsUpdatedOrder()
        {
            OrderDto? createdOrder = null;

            try
            {
                // Arrange
                createdOrder = await CreateOrderAsync();

                var updateOrderDto = new UpdateOrderDto
                {
                    Id = createdOrder.Id,
                    OrderStatusId = 2
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/orders/{createdOrder.Id}", updateOrderDto);
                response.EnsureSuccessStatusCode();

                // Assert
                var updatedOrder = await response.Content.ReadFromJsonAsync<OrderDto>();
                updatedOrder.Should().NotBeNull();
                updatedOrder?.OrderStatus.Id.Should().Be(2);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdOrder != null)
                {
                    await DeleteOrderAsync(createdOrder.Id);
                }
            }
        }
        [Fact]
        public async Task UpdateOrderAsync_ReturnsNotFound_WhenInvalidData()
        {
            // Arrange
            var invalidUpdateOrderDto = new UpdateOrderDto
            {
                Id = 999, // Non-existent Order ID
                OrderStatusId = 99 // Non-existent OrderStatusId
            };

            // Act
            var response = await Client.PutAsJsonAsync($"/api/orders/999", invalidUpdateOrderDto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnNoContent_WhenSuccessful()
        {
            OrderDto? createdOrder = null;

            try
            {
                // Arrange
                createdOrder = await CreateOrderAsync();

                // Act
                var response = await Client.DeleteAsync($"/api/orders/{createdOrder.Id}");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdOrder != null)
                {
                    await DeleteOrderAsync(createdOrder.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnNotFound_WhenOrderDoesNotExist()
        {
            // Act
            var response = await Client.DeleteAsync("/api/orders/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private async Task<OrderDto> CreateOrderAsync()
        {
            var newOrder = new CreateOrderDto
            {
                Reference = "ORD100",
                OrderDate = DateTime.UtcNow.AddYears(-1),
                ShippingCost = 20.00m,
                TotalAmount = 720.00m,
                CustomerId = 1,
                OrderStatusId = 1,
                OrderTypeId = 1,
                OrderItems =
                [
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                ]
            };
            var response = await Client.PostAsJsonAsync("/api/orders", newOrder);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<OrderDto>())!;
        }

        private async Task DeleteOrderAsync(int id)
        {
            await Client.DeleteAsync($"/api/orders/{id}");
        }
    }
}
