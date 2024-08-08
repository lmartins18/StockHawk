using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override async Task<Product?> GetByIdAsync(int id)
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<List<Product>> GetByIdsAsync(List<int> productIds)
    {
        return await Context.Set<Product>()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();
    }

    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => !p.IsDeleted)
            .ToListAsync();
    }

    public IEnumerable<Product> GetLowStockProducts()
        => Context.Products.Where(p => !p.IsDeleted && p.Quantity < p.LowStockThreshold);


    public async Task<List<Product>> GetLowStockProductsAsync() => await Context.Products
            .Where(product => product.Quantity < product.LowStockThreshold)
            .ToListAsync();

    public async Task<List<Product>> GetOutOfStockProductsAsync() => await Context.Products
            .Where(product => product.Quantity == 0)
            .ToListAsync();

}