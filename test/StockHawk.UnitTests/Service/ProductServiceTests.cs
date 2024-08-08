using AutoMapper;
using FluentAssertions;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.MappingProfiles;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service;

public class ProductServiceTests
{
    private readonly ProductService _productService;
    private readonly FakeProductRepository _productRepository;
    private readonly FakeCategoryRepository _categoryRepository;
    private readonly FakeSupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public ProductServiceTests()
    {
        _productRepository = new FakeProductRepository();
        _categoryRepository = new FakeCategoryRepository();
        _supplierRepository = new FakeSupplierRepository();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
            cfg.AddProfile<CategoryMappingProfile>();
            cfg.AddProfile<SupplierMappingProfile>();
        });
        _mapper = configuration.CreateMapper();

        _productService = new ProductService(
            _productRepository,
            _categoryRepository,
            _supplierRepository,
            _mapper
        );
    }

    [Fact]
    public async Task GetProductByIdAsync_ReturnsProductDto()
    {
        // Arrange
        var expected = await _productRepository.GetByIdAsync(1);

        // Act
        var result = await _productService.GetProductByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(expected!.Name);
    }

    [Fact]
    public async Task GetAllProductsAsync_ReturnsProductDtos()
    {
        // Arrange
        var products = await _productRepository.GetAllAsync();

        // Act
        var result = await _productService.GetAllProductsAsync();

        // Assert
        result.Should().HaveCount(products.Count());
        result.Should().BeEquivalentTo(products.Select(_mapper.Map<ProductDto>));
    }

    [Fact]
    public async Task CreateProductAsync_CreatesAndReturnsProductDto()
    {
        // Arrange
        var createDto = new CreateProductDto
        {
            Name = "NewProduct",
            Description = "NewDescription",
            Price = 30m,
            Quantity = 300,
            LowStockThreshold = 30,
            CategoryId = 3,
            SupplierId = 3
        };

        // Act
        var result = await _productService.CreateProductAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(createDto.Name);

        // Verify the product was added
        var createdProduct = await _productService.GetProductByIdAsync(result.Id);
        createdProduct.Should().NotBeNull();
        createdProduct!.Name.Should().Be(createDto.Name);
    }
    [Fact]
    public async Task CreateProductAsync_ShouldThrowDuplicateProductException_WhenProductWithSameNameCategoryAndSupplierExists()
    {
        // Arrange
        var product = await _productRepository.GetByIdAsync(1);

        var createProductDto = new CreateProductDto
        {
            Name = product!.Name,
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId,
            Description = "NewDescription"
        };

        // Act
        Func<Task> act = async () => await _productService.CreateProductAsync(createProductDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage($"A product with the name '{product.Name}' already exists in the specified category and supplier.");
    }


    [Fact]
    public async Task UpdateProductAsync_UpdatesProduct()
    {
        // Arrange
        var productDto = new UpdateProductDto
        {
            Id = 1,
            Name = "UpdatedProduct",
            Description = "UpdatedDescription",
            Price = 15m,
            Quantity = 150,
            LowStockThreshold = 15,
            CategoryId = 1,
            SupplierId = 1
        };

        // Act
        await _productService.UpdateProductAsync(productDto);

        // Assert
        var updatedProduct = await _productService.GetProductByIdAsync(1);
        updatedProduct.Should().NotBeNull();
        updatedProduct!.Name.Should().Be("UpdatedProduct");
        updatedProduct.Description.Should().Be("UpdatedDescription");
    }
    [Fact]
    public async Task UpdateProductAsync_ShouldThrowDuplicateEntityException_WhenProductWithSameNameCategoryAndSupplierExists()
    {
        // Arrange
        var product = await _productRepository.GetByIdAsync(1);
        var existingProduct = await _productRepository.GetByIdAsync(2);

        var updateProductDto = new UpdateProductDto
        {
            Id = product!.Id,
            Name = existingProduct!.Name,
            CategoryId = existingProduct.CategoryId,
            SupplierId = existingProduct.SupplierId,
            Description = "UpdatedDescription"
        };

        // Act
        Func<Task> act = async () => await _productService.UpdateProductAsync(updateProductDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage($"A product with the name '{existingProduct.Name}' already exists in the specified category and supplier.");
    }

    [Fact]
    public async Task UpdateProductAsync_ShouldNotThrowException_WhenUpdatingProductWithUniqueDetails()
    {
        // Arrange
        var product = await _productRepository.GetByIdAsync(1);

        var updateProductDto = new UpdateProductDto
        {
            Id = product!.Id,
            Name = "UniqueProductName",
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId,
            Description = "UpdatedDescription",
            Price = 20m,
            Quantity = 200,
            LowStockThreshold = 20
        };

        // Act
        Func<Task> act = async () => await _productService.UpdateProductAsync(updateProductDto);

        // Assert
        await act.Should().NotThrowAsync<DuplicateEntityException>();

        var updatedProduct = await _productService.GetProductByIdAsync(product.Id);
        updatedProduct.Should().NotBeNull();
        updatedProduct!.Name.Should().Be(updateProductDto.Name);
        updatedProduct.Description.Should().Be(updateProductDto.Description);
    }
    [Fact]
    public async Task DeleteProductAsync_DeletesProduct()
    {
        // Act
        await _productService.DeleteProductAsync(2);

        // Assert
        var deletedProduct = await _productService.GetProductByIdAsync(2);
        deletedProduct.Should().BeNull();
    }
}
