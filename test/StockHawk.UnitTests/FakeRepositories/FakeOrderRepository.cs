using StockHawk.Model;
using StockHawk.DataAccess.Repositories;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new()
    {
        new Order
        {
            Id = 1, Reference = "Order1", CustomerId = 1, OrderDate = DateTime.UtcNow.AddYears(-1), ShippingCost = 10, TotalAmount = 100,
            OrderStatusId = 1, OrderTypeId = 1,
            Customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789", Address = "123 Main St" },
            OrderStatus = new OrderStatus { Id = 1, Name = "Pending" },
            OrderType = new OrderType { Id = 1, Name = "Standard" },
            OrderItems = new List<OrderItem>()
        },
        new Order
        {
            Id = 2, Reference = "Order2", CustomerId = 2, OrderDate = DateTime.UtcNow.AddYears(-1), ShippingCost = 20, TotalAmount = 200,
            OrderStatusId = 2, OrderTypeId = 2,
            Customer = new Customer { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "987654321", Address = "456 Elm St" },
            OrderStatus = new OrderStatus { Id = 2, Name = "Shipped" },
            OrderType = new OrderType { Id = 2, Name = "Express" },
            OrderItems = new List<OrderItem>()
        }
    };

    public int Count => _orders.Count;

    public IEnumerable<Order> GetAll() => _orders;

    public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order entity) => _orders.Add(entity);

    public void Update(Order entity)
    {
        var order = _orders.FirstOrDefault(o => o.Id == entity.Id);
        if (order != null)
        {
            order.Reference = entity.Reference;
            order.CustomerId = entity.CustomerId;
            order.OrderDate = entity.OrderDate;
            order.ShippingCost = entity.ShippingCost;
            order.TotalAmount = entity.TotalAmount;
            order.OrderStatusId = entity.OrderStatusId;
            order.OrderTypeId = entity.OrderTypeId;
            order.Customer = entity.Customer;
            order.OrderStatus = entity.OrderStatus;
            order.OrderType = entity.OrderType;
            order.OrderItems = entity.OrderItems;
        }
    }

    public void Delete(Order entity) => _orders.Remove(entity);

    public async Task<IEnumerable<Order>> GetAllAsync() => await Task.FromResult(_orders);

    public async Task<Order?> GetByIdAsync(int id) => await Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

    public async Task AddAsync(Order entity)
    {
        _orders.Add(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Order entity)
    {
        var order = _orders.FirstOrDefault(o => o.Id == entity.Id);
        if (order != null)
        {
            order.Reference = entity.Reference;
            order.CustomerId = entity.CustomerId;
            order.OrderDate = entity.OrderDate;
            order.ShippingCost = entity.ShippingCost;
            order.TotalAmount = entity.TotalAmount;
            order.OrderStatusId = entity.OrderStatusId;
            order.OrderTypeId = entity.OrderTypeId;
            order.Customer = entity.Customer;
            order.OrderStatus = entity.OrderStatus;
            order.OrderType = entity.OrderType;
            order.OrderItems = entity.OrderItems;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Order entity)
    {
        _orders.Remove(entity);
        await Task.CompletedTask;
    }

    public IEnumerable<Order> GetOrdersByCustomer(int customerId) => _orders.Where(o => o.CustomerId == customerId);

    public async Task<List<Order>> GetRecentOrdersAsync() => await Task.FromResult(_orders.OrderByDescending(order => order.OrderDate)
            .Take(5).ToList());

    public async Task<decimal> GetTotalSalesAsync() => await Task.FromResult(_orders.Sum(order => order.TotalAmount));

    public async Task<int> CountAsync() => await Task.FromResult(_orders.Count);

    public async Task<IEnumerable<Order>> GetAllWithOrderItemsAsync() => await Task.FromResult(_orders);

    public async Task DeactivateAsync(Order entity)
    {
        var item = _orders.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("entity not found.");

        _orders.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}
