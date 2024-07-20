using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class ProductRepository : BaseRepository<Product>
{
    public ProductRepository(StockHawkDbContext context) : base(context) { }

    // Additional product-specific methods can be implemented here
    public IEnumerable<Product> GetLowStockProducts()
    {
        return Context.Products.Where(p => p.Quantity < p.LowStockThreshold);
    }
}
