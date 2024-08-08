using StockHawk.Model;
using StockHawk.DataAccess.Repositories;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Product1",
            Description = "Description1",
            Price = 10,
            Quantity = 100,
            LowStockThreshold = 10,
            CategoryId = 1,
            SupplierId = 1,
            Category = new Category { Id = 1, Name = "Category1", Description = "Category1 desc" },
            Supplier = new Supplier
            {
                Id = 1,
                Name = "Supplier1",
                ContactNumber = "123-456-7890",
                Email = "supplier1@example.com",
                Address = "123 Supplier St.",
                Products = new List<Product>()
            }
        },
        new Product
        {
            Id = 2,
            Name = "Product2",
            Description = "Description2",
            Price = 20,
            Quantity = 200,
            LowStockThreshold = 20,
            CategoryId = 2,
            SupplierId = 2,
            Category = new Category { Id = 2, Name = "Category2", Description = "Category2 desc" },
            Supplier = new Supplier
            {
                Id = 2,
                Name = "Supplier2",
                ContactNumber = "987-654-3210",
                Email = "supplier2@example.com",
                Address = "456 Supplier St.",
                Products = new List<Product>()
            }
        }
    };

    public int Count => _products.Count;

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product entity)
    {
        _products.Add(entity);
        var supplier = _products.FirstOrDefault(s => s.SupplierId == entity.SupplierId)?.Supplier;
        if (supplier != null)
        {
            supplier.Products.Add(entity);
        }
    }

    public void Update(Product entity)
    {
        var product = _products.FirstOrDefault(p => p.Id == entity.Id);
        if (product != null)
        {
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Quantity = entity.Quantity;
            product.LowStockThreshold = entity.LowStockThreshold;
            product.CategoryId = entity.CategoryId;
            product.SupplierId = entity.SupplierId;
            product.Category = entity.Category;
            product.Supplier = entity.Supplier;
        }
    }

    public void DeactivateProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            product.IsDeleted = true;
        }
    }



    public async Task<IEnumerable<Product>> GetAllAsync() => await Task.FromResult(_products);

    public async Task<Product?> GetByIdAsync(int id) =>
        await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public async Task AddAsync(Product entity)
    {
        _products.Add(entity);
        var supplier = _products.FirstOrDefault(s => s.SupplierId == entity.SupplierId)?.Supplier;
        if (supplier != null)
        {
            supplier.Products.Add(entity);
        }

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Product entity)
    {
        var product = _products.FirstOrDefault(p => p.Id == entity.Id);
        if (product != null)
        {
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Quantity = entity.Quantity;
            product.LowStockThreshold = entity.LowStockThreshold;
            product.CategoryId = entity.CategoryId;
            product.SupplierId = entity.SupplierId;
            product.Category = entity.Category;
            product.Supplier = entity.Supplier;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Product entity)
    {
        _products.Remove(entity);
        var supplier = _products.FirstOrDefault(s => s.SupplierId == entity.SupplierId)?.Supplier;
        supplier?.Products.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<List<Product>> GetByIdsAsync(List<int> productIds)
        => await Task.FromResult(_products.Where(p => productIds.Contains(p.Id)).ToList());

    public IEnumerable<Product> GetLowStockProducts()
    {
        return _products.Where(p => p.Quantity <= 10);
    }

    public async Task<List<Product>> GetLowStockProductsAsync()
    {
        return await Task.FromResult(GetLowStockProducts().ToList());
    }

    public async Task<List<Product>> GetOutOfStockProductsAsync()
    {
        return await Task.FromResult(_products.Where(p => p.Quantity == 0).ToList());
    }

    public async Task<List<Product>> GetTopSellingProductsAsync()
    {
        // Data is not that relavant here. 
        return await Task.FromResult(_products[0..1]);
    }

    public async Task<int> CountAsync()
    {
        return await Task.FromResult(_products.Count);
    }
    public async Task DeactivateAsync(Product entity)
    {
        var product = _products.FirstOrDefault(p => p.Id == entity.Id);
        if (product != null)
        {
            product.IsDeleted = true;
        }
        await Task.CompletedTask;
    }
}