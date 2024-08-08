using StockHawk.DataAccess.Repositories;
using StockHawk.Model;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeCategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new()
    {
        new Category { Id = 1, Name = "Category1", Description = "Description1" },
        new Category { Id = 2, Name = "Category2", Description = "Description2" },
        new Category
        {
            Id = 3,
            Name = "Category1",
            Description = "Description1",
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
                    SupplierId = 1
                }
            }
        }
    };

    public int Count => _categories.Count;

    public IEnumerable<Category> GetAll() => _categories;

    public Category? GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);

    public void Add(Category entity) => _categories.Add(entity);

    public void Update(Category entity)
    {
        var category = _categories.FirstOrDefault(c => c.Id == entity.Id);

        if (category == null) return;

        category.Name = entity.Name;
        category.Description = entity.Description;
        category.Products = entity.Products;
    }

    public void Delete(Category entity) => _categories.Remove(entity);

    public async Task<IEnumerable<Category>> GetAllAsync() => await Task.FromResult(_categories);

    public async Task<Category?> GetByIdAsync(int id) =>
        await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));

    public async Task AddAsync(Category entity)
    {
        _categories.Add(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Category entity)
    {
        var category = _categories.FirstOrDefault(c => c.Id == entity.Id);
        if (category != null)
        {
            category.Name = entity.Name;
            category.Description = entity.Description;
            category.Products = entity.Products;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Category entity)
    {
        _categories.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<int> CountAsync() => await Task.FromResult(_categories.Count);

    public async Task DeactivateAsync(Category entity)
    {
        var category = _categories.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("category not found.");

        _categories.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}