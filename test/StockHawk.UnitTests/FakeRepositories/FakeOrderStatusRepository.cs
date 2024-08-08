using StockHawk.DataAccess.Repositories;
using StockHawk.Model;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeOrderStatusRepository : IOrderStatusRepository
{
    private readonly List<OrderStatus> _orderStatuses;

    public FakeOrderStatusRepository()
    {
        _orderStatuses = new List<OrderStatus>
        {
            new OrderStatus { Id = 1, Name = "Pending", Description = "Order is pending" },
            new OrderStatus { Id = 2, Name = "Processing", Description = "Order is being processed" },
            new OrderStatus { Id = 3, Name = "Completed", Description = "Order has been completed" },
            new OrderStatus { Id = 4, Name = "Cancelled", Description = "Order has been cancelled" }
        };
    }

    public async Task<IEnumerable<OrderStatus>> GetAllAsync()
    {
        return await Task.FromResult(_orderStatuses);
    }


    public Task<OrderStatus?> GetByIdAsync(int id)
    {
        return Task.FromResult(_orderStatuses.FirstOrDefault(os => os.Id == id));
    }

    public Task AddAsync(OrderStatus orderStatus)
    {
        _orderStatuses.Add(orderStatus);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderStatus orderStatus)
    {
        var existingOrderStatus = _orderStatuses.FirstOrDefault(os => os.Id == orderStatus.Id);
        if (existingOrderStatus != null)
        {
            existingOrderStatus.Name = orderStatus.Name;
            existingOrderStatus.Description = orderStatus.Description;
        }

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(OrderStatus entity)
    {
        var orderStatus = _orderStatuses.FirstOrDefault(os => os.Id == entity.Id);
        if (orderStatus != null)
        {
            _orderStatuses.Remove(orderStatus);
        }

        await Task.CompletedTask;
    }

    public async Task<int> CountAsync() => await Task.FromResult(_orderStatuses.Count);

    public async Task DeactivateAsync(OrderStatus entity)
    {
        var item = _orderStatuses.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("entity not found.");

        _orderStatuses.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}