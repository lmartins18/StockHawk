using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers
{
    public class CustomerControllerTests : IntegrationTestAuthBase
    {
        public CustomerControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetAllCustomersAsync_ReturnsAllCustomers()
        {
            // Act
            var response = await Client.GetAsync("/api/customers");
            response.EnsureSuccessStatusCode();

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("John");
            responseString.Should().Contain("Jane");
        }

        [Fact]
        public async Task GetCustomerByIdAsync_ReturnsCustomer_WhenCustomerExists()
        {
            CustomerDto? createdCustomer = null;

            try
            {
                // Arrange
                createdCustomer = await CreateCustomerAsync("Test", "Customer");

                // Act
                var response = await Client.GetAsync($"/api/customers/{createdCustomer.Id}");
                response.EnsureSuccessStatusCode();

                // Assert
                var responseCustomer = await response.Content.ReadFromJsonAsync<CustomerDto>();
                responseCustomer.Should().NotBeNull();
                responseCustomer?.FirstName.Should().Be("Test");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCustomer != null)
                {
                    await ForceForceDeleteCustomerAsync(createdCustomer.Id);
                }
            }
        }

        [Fact]
        public async Task CreateCustomerAsync_ReturnsCreatedCustomer()
        {
            CustomerDto? createdCustomer = null;

            try
            {
                // Arrange
                var newCustomer = new CreateCustomerDto
                {
                    FirstName = "Test",
                    LastName = "Customer",
                    Email = "test.customer@example.com",
                    PhoneNumber = "123123",
                    Address = "Customer land"
                };

                // Act
                var response = await Client.PostAsJsonAsync("/api/customers", newCustomer);
                response.EnsureSuccessStatusCode();

                // Assert
                createdCustomer = await response.Content.ReadFromJsonAsync<CustomerDto>();
                createdCustomer.Should().NotBeNull();
                createdCustomer?.FirstName.Should().Be("Test");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCustomer != null)
                {
                    await ForceForceDeleteCustomerAsync(createdCustomer.Id);
                }
            }
        }

        [Fact]
        public async Task CreateCustomerAsync_ReturnsBadRequest_WhenCustomerIsInvalid()
        {
            // Arrange
            var invalidCustomer = new CreateCustomerDto
            {
                FirstName = default!,
                LastName = default!,
                Email = default!,
                PhoneNumber = default!,
                Address = default!
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/customers", invalidCustomer);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ReturnsUpdatedCustomer()
        {
            CustomerDto? createdCustomer = null;

            try
            {
                // Arrange
                createdCustomer = await CreateCustomerAsync("Bob", "Builder");

                var updatedCustomerDto = new UpdateCustomerDto
                {
                    Id = createdCustomer.Id,
                    FirstName = "Robert",
                    LastName = "Builder"
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/customers/{createdCustomer.Id}", updatedCustomerDto);
                response.EnsureSuccessStatusCode();

                // Assert
                var updatedCustomer = await response.Content.ReadFromJsonAsync<CustomerDto>();
                updatedCustomer.Should().NotBeNull();
                updatedCustomer?.FirstName.Should().Be("Robert");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCustomer != null)
                {
                    await ForceForceDeleteCustomerAsync(createdCustomer.Id);
                }
            }
        }

        [Fact]
        public async Task DeactivateCustomerAsync_ShouldReturnNoContent_WhenSuccessful()
        {
            CustomerDto? createdCustomer = null;

            try
            {
                // Arrange
                createdCustomer = await CreateCustomerAsync("Charlie", "Brown");

                // Act
                var response = await Client.DeleteAsync($"/api/customers/{createdCustomer.Id}");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCustomer != null)
                {
                    await ForceForceDeleteCustomerAsync(createdCustomer.Id);
                }
            }
        }

        [Fact]
        public async Task DeactivateCustomerAsync_ShouldReturnNotFound_WhenCustomerDoesNotExist()
        {
            // Act
            var response = await Client.DeleteAsync("/api/customers/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private async Task<CustomerDto> CreateCustomerAsync(string firstName, string lastName)
        {
            var createCustomerDto = new CreateCustomerDto
            {
                FirstName = firstName,
                LastName = lastName,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}@example.com",
                PhoneNumber = "123123",
                Address = "123 Test St"
            };
            var response = await Client.PostAsJsonAsync("/api/customers", createCustomerDto);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<CustomerDto>())!;
        }

        private async Task ForceForceDeleteCustomerAsync(int id)
        {
            await Client.DeleteAsync($"/api/customers/{id}?forceDelete=true");
        }

    }
}
