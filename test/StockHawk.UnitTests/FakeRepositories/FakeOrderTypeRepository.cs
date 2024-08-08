using StockHawk.DataAccess.Repositories;
using StockHawk.Model;

namespace StockHawk.UnitTests.FakeRepositories;

public class FakeOrderTypeRepository : IOrderTypeRepository
{
    private readonly List<OrderType> _orderTypes;

    public FakeOrderTypeRepository()
    {
        _orderTypes = new List<OrderType>
        {
            new OrderType { Id = 1, Name = "Online", Description = "Order placed online" },
            new OrderType { Id = 2, Name = "In-Store", Description = "Order placed in-store" },
            new OrderType { Id = 3, Name = "Phone", Description = "Order placed over the phone" }
        };
    }


    public async Task<IEnumerable<OrderType>> GetAllAsync()
    {
        return await Task.FromResult(_orderTypes);
    }

    public Task<OrderType?> GetByIdAsync(int id)
    {
        return Task.FromResult(_orderTypes.FirstOrDefault(ot => ot.Id == id));
    }

    public Task AddAsync(OrderType orderType)
    {
        _orderTypes.Add(orderType);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderType orderType)
    {
        var existingOrderType = _orderTypes.FirstOrDefault(ot => ot.Id == orderType.Id);
        if (existingOrderType != null)
        {
            existingOrderType.Name = orderType.Name;
            existingOrderType.Description = orderType.Description;
        }

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(OrderType entity)
    {
        var orderType = _orderTypes.FirstOrDefault(ot => ot.Id == entity.Id);
        if (orderType != null)
        {
            _orderTypes.Remove(orderType);
        }

        await Task.CompletedTask;
    }

    public async Task<int> CountAsync() => await Task.FromResult(_orderTypes.Count);

    public async Task DeactivateAsync(OrderType entity)
    {
        var item = _orderTypes.FirstOrDefault(o => o.Id == entity.Id) ?? throw new KeyNotFoundException("entity not found.");

        _orderTypes.ForEach(c =>
        {
            if (c.Id == entity.Id)
            {
                c.IsDeleted = true;
            }
        });

        await Task.CompletedTask;

    }
}