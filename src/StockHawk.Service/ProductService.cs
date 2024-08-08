using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.Utilities;

namespace StockHawk.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductDto>> GetAllValidProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto?>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
    {
        Product? existingProduct = await VerifyIfProductExists(createProductDto);

        if (existingProduct != null)
        {
            throw new DuplicateEntityException($"A product with the name '{createProductDto.Name}' already exists in the specified category and supplier.");
        }
        var product = _mapper.Map<Product>(createProductDto);

        await SetCategoryAndSupplierAsync(product, createProductDto.CategoryId, createProductDto.SupplierId);

        await _productRepository.AddAsync(product);

        return _mapper.Map<ProductDto>(product);
    }
    // TODO: This has to be improved in term of performance.

    private async Task<Product?> VerifyIfProductExists(CreateProductDto createProductDto)
    {
        return (await _productRepository
        .GetAllAsync()).FirstOrDefault(p => p.Name == createProductDto.Name
                                    && p.CategoryId == createProductDto.CategoryId
                                    && p.SupplierId == createProductDto.SupplierId);
    }

    public async Task<ProductDto?> UpdateProductAsync(UpdateProductDto productDto)
    {
        // Verify if the product exists with the same name, category, and supplier.
        Product? existingProduct = await VerifyIfProductExists(_mapper.Map<CreateProductDto>(productDto));

        if (existingProduct != null && existingProduct.Id != productDto.Id)
        {
            throw new DuplicateEntityException($"A product with the name '{productDto.Name}' already exists in the specified category and supplier.");
        }

        // Fetch the existing product from the repository.
        var product = await _productRepository.GetByIdAsync(productDto.Id);
        if (product is null) return null;

        // Fetch the new category and supplier.
        if (productDto.CategoryId.HasValue)
        {
            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId.Value)
                            ?? throw new ArgumentException($"Category with ID {productDto.CategoryId} was not found.");
            product.Category = category;
        }
        if (productDto.SupplierId.HasValue)
        {
            var supplier = await _supplierRepository.GetByIdAsync(productDto.SupplierId.Value)
                            ?? throw new ArgumentException($"Supplier with ID {productDto.SupplierId} was not found.");
            product.Supplier = supplier;
        }

        // Apply other updates to the product entity.
        UpdateHelper.ApplyUpdates(productDto, product);

        // Update the product in the repository.
        await _productRepository.UpdateAsync(product);

        // Return the updated product mapped to a DTO.
        return _mapper.Map<ProductDto>(product);
    }


    public async Task<int?> DeactivateProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null) return null;

        await _productRepository.DeactivateAsync(product);
        return id;
    }
    public async Task<int?> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null) return null;

        await _productRepository.DeleteAsync(product);
        return id;
    }

    private async Task SetCategoryAndSupplierAsync(Product product, int categoryId, int supplierId)
    {
        product.Category = (await _categoryRepository.GetByIdAsync(categoryId))!;
        product.Supplier = (await _supplierRepository.GetByIdAsync(supplierId))!;

        if (product.Category == null)
        {
            throw new ArgumentException("Invalid category ID");
        }

        if (product.Supplier == null)
        {
            throw new ArgumentException("Invalid supplier ID");
        }
    }
    public async Task<int> GetProductCountAsync()
    {
        return await _productRepository.CountAsync();
    }

    public async Task<List<ProductDto>> GetLowStockProductsAsync()
    {
        List<Product> lowStockProducts = await _productRepository.GetLowStockProductsAsync();
        return _mapper.Map<List<ProductDto>>(lowStockProducts);

    }

    public async Task<List<ProductDto>> GetOutOfStockProductsAsync()
    {
        List<Product> outOfStockProducts = await _productRepository.GetOutOfStockProductsAsync();
        return _mapper.Map<List<ProductDto>>(outOfStockProducts);
    }

}