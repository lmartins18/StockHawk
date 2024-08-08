using StockHawk.Model;
using StockHawk.DataAccess.Repositories;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeSupplierRepository : ISupplierRepository
{
    private readonly List<Supplier> _suppliers = new()
    {
        new Supplier
        {
            Id = 1,
            Name = "Supplier1",
            ContactNumber = "123-456-7890",
            Email = "supplier1@example.com",
            Address = "123 Supplier St.",
            Products = new List<Product>
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
                    Category = new Category { Id = 1, Name = "Category1", Description = "Category1 desc" }
                }
            }
        },
        new Supplier
        {
            Id = 2,
            Name = "Supplier2",
            ContactNumber = "987-654-3210",
            Email = "supplier2@example.com",
            Address = "456 Supplier St.",
            Products = new List<Product>
            {
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
                    Category = new Category { Id = 2, Name = "Category2", Description = "Category2 desc" }
                }
            }
        },
        new Supplier
        {
            Id = 3,
            Name = "Supplier3",
            ContactNumber = "987-654-3210",
            Email = "supplier3@example.com",
            Address = "456 Supplier St.",
            Products = new List<Product>()
        }
    };

    public int Count => _suppliers.Count;

    public IEnumerable<Supplier> GetAll() => _suppliers;

    public Supplier? GetById(int id) => _suppliers.FirstOrDefault(s => s.Id == id);

    public void Add(Supplier entity) => _suppliers.Add(entity);

    public void Update(Supplier entity)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.Id == entity.Id);
        if (supplier != null)
        {
            supplier.Name = entity.Name;
            supplier.ContactNumber = entity.ContactNumber;
            supplier.Email = entity.Email;
            supplier.Address = entity.Address;
            supplier.Products = entity.Products;
        }
    }

    public void Delete(Supplier entity) => _suppliers.Remove(entity);

    public async Task<IEnumerable<Supplier>> GetAllAsync() => await Task.FromResult(_suppliers);

    public async Task<Supplier?> GetByIdAsync(int id) =>
        await Task.FromResult(_suppliers.FirstOrDefault(s => s.Id == id));

    public async Task AddAsync(Supplier entity)
    {
        _suppliers.Add(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Supplier entity)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.Id == entity.Id);
        if (supplier != null)
        {
            supplier.Name = entity.Name;
            supplier.ContactNumber = entity.ContactNumber;
            supplier.Email = entity.Email;
            supplier.Address = entity.Address;
            supplier.Products = entity.Products;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Supplier entity)
    {
        _suppliers.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<int> CountAsync() => await Task.FromResult(_suppliers.Count);

    public async Task DeactivateAsync(Supplier entity)
    {
        var item = _suppliers.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("entity not found.");

        _suppliers.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}