using StockHawk.Model;
using StockHawk.DataAccess.Repositories;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new()
    {
        new Customer
        {
            Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "1234567890",
            Address = "123 Main St", Orders = new List<Order>()
        },
        new Customer
        {
            Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", PhoneNumber = "0987654321",
            Address = "456 Elm St", Orders = new List<Order>()
        }
    };

    public int Count => _customers.Count;

    public IEnumerable<Customer> GetAll() => _customers;

    public Customer? GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);

    public void Add(Customer entity) => _customers.Add(entity);

    public void Update(Customer entity)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == entity.Id);

        if (customer == null) return;

        customer.FirstName = entity.FirstName;
        customer.LastName = entity.LastName;
        customer.Email = entity.Email;
        customer.PhoneNumber = entity.PhoneNumber;
        customer.Address = entity.Address;
        customer.Orders = entity.Orders;
    }

    public void Delete(Customer entity) => _customers.Remove(entity);

    public async Task<IEnumerable<Customer>> GetAllAsync() => await Task.FromResult(_customers);

    public async Task<Customer?> GetByIdAsync(int id) =>
        await Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));

    public async Task AddAsync(Customer entity)
    {
        _customers.Add(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Customer entity)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == entity.Id);
        if (customer != null)
        {
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Email = entity.Email;
            customer.PhoneNumber = entity.PhoneNumber;
            customer.Address = entity.Address;
            customer.Orders = entity.Orders;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Customer entity)
    {
        _customers.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<int> CountAsync() => await Task.FromResult(_customers.Count);

    public async Task DeactivateAsync(Customer entity)
    {
        var item = _customers.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("entity not found.");

        _customers.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}
