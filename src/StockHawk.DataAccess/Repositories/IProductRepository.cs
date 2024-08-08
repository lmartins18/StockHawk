using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> GetByIdsAsync(List<int> productIds);
    IEnumerable<Product> GetLowStockProducts();
    Task<List<Product>> GetLowStockProductsAsync();
    Task<List<Product>> GetOutOfStockProductsAsync();

}