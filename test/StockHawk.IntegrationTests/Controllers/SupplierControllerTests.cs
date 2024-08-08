using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers
{
    public class SupplierControllerTests : IntegrationTestAuthBase
    {
        private readonly CreateSupplierDto testSupplier = new()
        {
            Name = "Supplier With Products",
            ContactNumber = "123-456-7890",
            Email = "supplierproducts@example.com",
            Address = "123 Product Lane"
        };

        public SupplierControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        // Test for getting all suppliers
        [Fact]
        public async Task GetAllSuppliers_ShouldReturnOk_WithSuppliersList()
        {
            // Act
            var response = await Client.GetAsync("/api/suppliers");

            // Assert
            response.EnsureSuccessStatusCode();
            var suppliers = await response.Content.ReadFromJsonAsync<IEnumerable<SupplierDto>>();
            suppliers.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetSupplierById_ShouldReturnOk_WhenSupplierExists()
        {
            // Arrange
            SupplierDto? createdSupplier = null;
            try
            {
                createdSupplier = await CreateSupplierAsync();

                // Act
                var response = await Client.GetAsync($"/api/suppliers/{createdSupplier.Id}");

                // Assert
                response.EnsureSuccessStatusCode();
                var supplier = await response.Content.ReadFromJsonAsync<SupplierDto>();
                supplier.Should().NotBeNull();
                supplier!.Id.Should().Be(createdSupplier.Id);
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
            finally
            {
                if (createdSupplier != null)
                {
                    await DeleteSupplierAsync(createdSupplier.Id);
                }
            }
        }

        // Test for getting a supplier by non-existent ID
        [Fact]
        public async Task GetSupplierById_ShouldReturnNotFound_WhenSupplierDoesNotExist()
        {
            // Act
            var response = await Client.GetAsync("/api/suppliers/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        // Test for creating a supplier
        [Fact]
        public async Task CreateSupplier_ShouldReturnCreated_WhenSuccessful()
        {
            SupplierDto? createdSupplier = null;
            try
            {
                // Arrange & Act
                createdSupplier = await CreateSupplierAsync();

                // Assert
                createdSupplier.Should().NotBeNull();
                createdSupplier!.Name.Should().Be(createdSupplier.Name);
                createdSupplier.ContactNumber.Should().Be(createdSupplier.ContactNumber);
                createdSupplier.Email.Should().Be(createdSupplier.Email);
                createdSupplier.Address.Should().Be(createdSupplier.Address);
            }
            finally
            {
                if (createdSupplier != null)
                {
                    await DeleteSupplierAsync(createdSupplier.Id);
                }
            }
        }

        // Test for creating a duplicate supplier
        [Fact]
        public async Task CreateSupplier_ShouldReturnConflict_WhenSupplierAlreadyExists()
        {
            SupplierDto? createdSupplier = null;

            try
            {
                // Arrange & Act
                createdSupplier = await CreateSupplierAsync();
                var response = await Client.PostAsJsonAsync("/api/suppliers", testSupplier);

                // Assert
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
            }
            finally
            {
                if (createdSupplier != null)
                {
                    await DeleteSupplierAsync(createdSupplier.Id);
                }
            }
        }

        // Test for updating a supplier
        [Fact]
        public async Task UpdateSupplier_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            SupplierDto? createdSupplier = null;
            try
            {
                createdSupplier = await CreateSupplierAsync();

                var updatedSupplier = new SupplierDto
                {
                    Id = createdSupplier.Id,
                    Name = "Updated Supplier",
                    ContactNumber = "987-654-3210",
                    Email = "updated@example.com",
                    Address = "789 Updated Road"
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/suppliers/{createdSupplier.Id}", updatedSupplier);

                // Assert
                response.EnsureSuccessStatusCode();
                var supplier = await response.Content.ReadFromJsonAsync<SupplierDto>();
                supplier.Should().NotBeNull();
                supplier!.Name.Should().Be(updatedSupplier.Name);
                supplier.ContactNumber.Should().Be(updatedSupplier.ContactNumber);
                supplier.Email.Should().Be(updatedSupplier.Email);
                supplier.Address.Should().Be(updatedSupplier.Address);
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
            finally
            {
                if (createdSupplier != null)
                {
                    await DeleteSupplierAsync(createdSupplier.Id);
                }
            }
        }

        // Test for updating a non-existent supplier
        [Fact]
        public async Task UpdateSupplier_ShouldReturnNotFound_WhenSupplierDoesNotExist()
        {
            // Arrange
            var updatedSupplier = new SupplierDto
            {
                Id = 999,
                Name = "Non-existent Supplier",
                ContactNumber = "000-000-0000",
                Email = "nonexistent@example.com",
                Address = "000 Nowhere Lane"
            };

            // Act
            var response = await Client.PutAsJsonAsync("/api/suppliers/999", updatedSupplier);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        // Test for deleting a supplier
        [Fact]
        public async Task DeleteSupplier_ShouldReturnNoContent_WhenSuccessful()
        {
            SupplierDto? createdSupplier = null;
            try
            {
                createdSupplier = await CreateSupplierAsync();

                // Act
                var response = await Client.DeleteAsync($"/api/suppliers/{createdSupplier.Id}");

                // Assert
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                if (createdSupplier != null)
                {
                    await DeleteSupplierAsync(createdSupplier.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteSupplier_ShouldReturnBadRequest_WhenSupplierHasAssociatedProducts()
        {
            // Arrange
            SupplierDto? supplierWithProducts = null;
            List<int> productIds = new List<int>();
            try
            {
                supplierWithProducts = await CreateSupplierWithProductsAsync();
                // Retrieve the product IDs for cleanup
                productIds = await GetProductIdsBySupplierAsync(supplierWithProducts.Id);

                // Act
                var response = await Client.DeleteAsync($"/api/suppliers/{supplierWithProducts.Id}");

                // Assert
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            }
            finally
            {
                // Ensure associated products are deleted
                foreach (var productId in productIds)
                {
                    await DeleteProductAsync(productId);
                }

                if (supplierWithProducts != null)
                {
                    await DeleteSupplierAsync(supplierWithProducts.Id);
                }
            }
        }



        // Test for deleting a non-existent supplier
        [Fact]
        public async Task DeleteSupplier_ShouldReturnNotFound_WhenSupplierDoesNotExist()
        {
            // Act
            var response = await Client.DeleteAsync("/api/suppliers/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        // Helper method to create a supplier
        private async Task<SupplierDto> CreateSupplierAsync()
        {

            var response = await Client.PostAsJsonAsync("/api/suppliers", testSupplier);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<SupplierDto>())!;
        }

        // Helper method to create a supplier with associated products
        private async Task<SupplierDto> CreateSupplierWithProductsAsync()
        {
            var newSupplier = testSupplier;

            var response = await Client.PostAsJsonAsync("/api/suppliers", newSupplier);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            var createdSupplier = await response.Content.ReadFromJsonAsync<SupplierDto>();

            // Now add products to this supplier
            CreateProductDto? productDto = new()
            {
                Name = "Test Product",
                CategoryId = 1,
                Description = "Test Description",
                SupplierId = createdSupplier!.Id
            };

            var productResponse = await Client.PostAsJsonAsync("/api/products", productDto);
            productResponse.EnsureSuccessStatusCode();

            return createdSupplier!;
        }

        // Helper method to delete a supplier
        private async Task DeleteSupplierAsync(int id)
        {
            var response = await Client.DeleteAsync($"/api/suppliers/{id}");
            response.EnsureSuccessStatusCode();
        }
        // Helper method to get product IDs by supplier
        private async Task<List<int>> GetProductIdsBySupplierAsync(int supplierId)
        {
            // Simulating getting products by supplier. 
            // Adjust this based on how you create products in your test
            var response = await Client.GetAsync($"/api/products"); // Assuming this retrieves all products
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();

            return products!.Where(p => p.Supplier.Id == supplierId).Select(p => p.Id).ToList();
        }

        // Helper method to delete a product by ID
        private async Task DeleteProductAsync(int productId)
        {
            var response = await Client.DeleteAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
        }

    }
}
