using System.Net.Http.Json;
using FluentAssertions;
using StockHawk.Service.DTOs;

namespace StockHawk.IntegrationTests.Controllers
{
    public class CategoryControllerTests : IntegrationTestAuthBase
    {
        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ReturnsAllCategories()
        {
            // Act
            var response = await Client.GetAsync("/api/categories");
            response.EnsureSuccessStatusCode();

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNull();


        }

        [Fact]
        public async Task GetCategoryById_ReturnsCategory_WhenCategoryExists()
        {
            CategoryDto? createdCategory = null;

            try
            {
                // Arrange
                createdCategory = await CreateCategoryAsync("Toys");

                // Act
                var response = await Client.GetAsync($"/api/categories/{createdCategory.Id}");
                response.EnsureSuccessStatusCode();

                // Assert
                var responseCategory = await response.Content.ReadFromJsonAsync<CategoryDto>();
                responseCategory.Should().NotBeNull();
                responseCategory?.Name.Should().Be("Toys");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCategory != null)
                {
                    await DeleteCategoryAsync(createdCategory.Id);
                }
            }
        }

        [Fact]
        public async Task GetCategoryById_ReturnsNotFound_WhenCategoryDoesNotExist()
        {
            // Act
            var response = await Client.GetAsync("/api/categories/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateCategory_ReturnsCreatedCategory()
        {
            CategoryDto? createdCategory = null;

            try
            {
                // Arrange
                var newCategory = new CreateCategoryDto
                {
                    Name = "Furniture",
                    Description = "For furnitures"
                };

                // Act
                var response = await Client.PostAsJsonAsync("/api/categories", newCategory);
                response.EnsureSuccessStatusCode();

                // Assert
                createdCategory = await response.Content.ReadFromJsonAsync<CategoryDto>();
                createdCategory.Should().NotBeNull();
                createdCategory?.Name.Should().Be("Furniture");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCategory != null)
                {
                    await DeleteCategoryAsync(createdCategory.Id);
                }
            }
        }

        [Fact]
        public async Task CreateCategory_ReturnsBadRequest_WhenCategoryIsInvalid()
        {
            // Arrange
            var invalidCategory = new CreateCategoryDto
            {
                Name = default!,
                Description = default!
            };

            // Act
            var response = await Client.PostAsJsonAsync("/api/categories", invalidCategory);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsUpdatedCategory()
        {
            CategoryDto? createdCategory = null;

            try
            {
                // Arrange
                createdCategory = await CreateCategoryAsync("Appliances");

                var updatedCategoryDto = new UpdateCategoryDto
                {
                    Id = createdCategory.Id,
                    Name = "Test Home Appliances",
                    Description = createdCategory.Description
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/categories/{createdCategory.Id}", updatedCategoryDto);
                response.EnsureSuccessStatusCode();

                // Assert
                var updatedCategory = await response.Content.ReadFromJsonAsync<CategoryDto>();
                updatedCategory.Should().NotBeNull();
                updatedCategory?.Name.Should().Be("Test Home Appliances");
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCategory != null)
                {
                    await DeleteCategoryAsync(createdCategory.Id);
                }
            }
        }
        [Fact]
        public async Task UpdateCategory_ReturnsNotFound_WhenCategoryDoesNotExist()
        {
            // Arrange
            var updateCategoryDto = new UpdateCategoryDto
            {
                Id = 999, // Non-existent ID
                Name = "Non-Existent Category",
                Description = "test"
            };

            // Act
            var response = await Client.PutAsJsonAsync("/api/categories/999", updateCategoryDto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsConflict_WhenCategoryNameAlreadyExists()
        {
            CategoryDto? createdCategory1 = null;
            CategoryDto? createdCategory2 = null;

            try
            {
                // Arrange
                createdCategory1 = await CreateCategoryAsync("Test Electronics");
                createdCategory2 = await CreateCategoryAsync("Test Gadgets");

                var updateCategoryDto = new UpdateCategoryDto
                {
                    Id = createdCategory2.Id,
                    Name = "Electronics", // Name that already exists
                    Description = "test"
                };

                // Act
                var response = await Client.PutAsJsonAsync($"/api/categories/{createdCategory2.Id}", updateCategoryDto);

                // Assert
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
            }
            finally
            {
                if (createdCategory1 != null)
                {
                    await DeleteCategoryAsync(createdCategory1.Id);
                }
                if (createdCategory2 != null)
                {
                    await DeleteCategoryAsync(createdCategory2.Id);
                }
            }
        }


        [Fact]
        public async Task DeleteCategory_ShouldReturnNoContent_WhenSuccessful()
        {
            CategoryDto? createdCategory = null;

            try
            {
                // Arrange
                createdCategory = await CreateCategoryAsync("Sports");

                // Act
                var response = await Client.DeleteAsync($"/api/categories/{createdCategory.Id}");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
            finally
            {
                // Clean up in case of a failure
                if (createdCategory != null)
                {
                    await DeleteCategoryAsync(createdCategory.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteCategory_ShouldReturnNotFound_WhenCategoryDoesNotExist()
        {
            // Act
            var response = await Client.DeleteAsync("/api/categories/999");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task DeleteCategory_ShouldReturnBadRequest_WhenCategoryHasProducts()
        {
            CategoryDto? createdCategory = null;
            int productId = 0;

            try
            {
                // Arrange
                createdCategory = await CreateCategoryAsync("Test Clothing");
                var productDto = await AddProductToCategoryAsync(createdCategory.Id);
                productId = productDto!.Id;

                // Act
                var response = await Client.DeleteAsync($"/api/categories/{createdCategory.Id}");

                // Assert
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            }
            finally
            {
                if (createdCategory != null)
                {
                    // Clean up product
                    await Client.DeleteAsync($"/api/products/{productId}?forceDelete=true");
                    // Clean up the category
                    await DeleteCategoryAsync(createdCategory.Id);
                }
            }
        }

        private async Task<CategoryDto> CreateCategoryAsync(string name)
        {
            var createCategoryDto = new CreateCategoryDto
            {
                Name = name,
                Description = "Test Description"
            };
            var response = await Client.PostAsJsonAsync("/api/categories", createCategoryDto);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<CategoryDto>())!;
        }

        private async Task DeleteCategoryAsync(int id)
        {
            await Client.DeleteAsync($"/api/categories/{id}");
        }

        private async Task<ProductDto?> AddProductToCategoryAsync(int categoryId)
        {
            var newProduct = new CreateProductDto
            {
                Name = "Product" + DateTime.UtcNow.Ticks,
                Price = 10.99M,
                Quantity = 100,
                CategoryId = categoryId,
                SupplierId = 1, // Assuming supplier with ID 1 exists
                Description = "Test Description"
            };

            var response = await Client.PostAsJsonAsync("/api/products", newProduct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }
    }
}
