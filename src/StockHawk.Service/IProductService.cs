using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    Task<ProductDto?> UpdateProductAsync(UpdateProductDto productDto);
    Task<int?> DeactivateProductAsync(int id);
    Task<int?> DeleteProductAsync(int id);
    Task<int> GetProductCountAsync();
    Task<List<ProductDto>> GetLowStockProductsAsync();
    Task<List<ProductDto>> GetOutOfStockProductsAsync();

}