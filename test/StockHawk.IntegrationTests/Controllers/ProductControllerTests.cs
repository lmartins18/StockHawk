using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers
{
    public class ProductControllerTests : IntegrationTestAuthBase
    {
        public ProductControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        private CreateProductDto testProduct = new CreateProductDto
        {
            Name = "Tester",
            Description = "High-quality tester",
            Price = 1000000m,
            Quantity = 1,
            LowStockThreshold = 0,
            CategoryId = 1,
            SupplierId = 1
        };

        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Act
            var response = await Client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("Smartphone");
            responseString.Should().Contain("Washing Machine");
            responseString.Should().Contain("Novel");
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnsProduct_WhenProductExists()
        {
            ProductDto? createdProduct = null;

            try
            {
                // Arrange
                createdProduct = await CreateProductAsync();

                // Act
                var response = await Client.GetAsync($"/api/products/{createdProduct.Id}");
                response.EnsureSuccessStatusCode();

                // Assert
                var responseProduct = await response.Content.ReadFromJsonAsync<ProductDto>();
                responseProduct.Should().NotBeNull();
                responseProduct?.Name.Should().Be(testProduct.Name);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdProduct != null)
                {
                    await ForceDeleteProductAsync(createdProduct.Id);
                }
            }
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Act
            var response = await Client.GetAsync("/api/products/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateProductAsync_ReturnsCreatedProduct()
        {
            ProductDto? createdProduct = null;

            try
            {
                // Act
                createdProduct = await CreateProductAsync();

                // Assert
                createdProduct.Should().NotBeNull();
                createdProduct?.Name.Should().Be(testProduct.Name);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdProduct != null)
                {
                    await ForceDeleteProductAsync(createdProduct.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsUpdatedProduct()
        {
            ProductDto? createdProduct = null;

            try
            {
                // Arrange
                createdProduct = await CreateProductAsync();

                var updateProductDto = new UpdateProductDto
                {
                    Id = createdProduct.Id,
                    Name = "Updated Tester",
                    Description = "Updated high-performance laptop",
                    Price = 999.99m,
                    Quantity = 15,
                    LowStockThreshold = 3,
                    CategoryId = createdProduct.Category.Id,
                    SupplierId = createdProduct.Supplier.Id
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/products/{createdProduct.Id}", updateProductDto);
                response.EnsureSuccessStatusCode();

                // Assert
                var updatedProduct = await response.Content.ReadFromJsonAsync<ProductDto>();
                updatedProduct.Should().NotBeNull();
                updatedProduct?.Name.Should().Be("Updated Tester");
                updatedProduct?.Description.Should().Be("Updated high-performance laptop");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdProduct != null)
                {
                    await ForceDeleteProductAsync(createdProduct.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var updateProductDto = new UpdateProductDto
            {
                Id = 999, // Non-existent product ID
                Name = "Non-existent Product",
                Description = "This product does not exist",
                Price = 999.99m,
                Quantity = 15,
                LowStockThreshold = 3,
                CategoryId = 1,
                SupplierId = 1
            };

            // Act
            var response = await Client.PutAsJsonAsync("/api/products/999", updateProductDto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ForceDeleteProductAsync_ShouldReturnNoContent_WhenSuccessful()
        {
            ProductDto? createdProduct = null;

            try
            {
                // Arrange
                createdProduct = await CreateProductAsync();

                // Act
                var response = await Client.DeleteAsync($"/api/products/{createdProduct.Id}?forceDelete=true");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdProduct != null)
                {
                    await ForceDeleteProductAsync(createdProduct.Id);
                }
            }
        }

        [Fact]
        public async Task ForceDeleteProductAsync_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            // Act
            var response = await Client.DeleteAsync("/api/products/999?forceDelete=true");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private async Task ForceDeleteProductAsync(int id)
        {
            await Client.DeleteAsync($"/api/products/{id}?forceDelete=true");
        }

        private async Task<ProductDto> CreateProductAsync()
        {
            var response = await Client.PostAsJsonAsync("/api/products", testProduct);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<ProductDto>())!;
        }
    }
}
