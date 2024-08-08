using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override Task<Order?> GetByIdAsync(int id)
    {
        return Context.Set<Order>()
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderType)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ThenInclude(p => p.Category)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ThenInclude(p => p.Supplier)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Context.Set<Order>()
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderType)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetAllWithOrderItemsAsync()
    {
        return await Context.Set<Order>()
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderType)
            .Include(o => o.OrderItems)
            .ToListAsync();
    }
    // Additional order-specific methods can be implemented here
    public IEnumerable<Order> GetOrdersByCustomer(int customerId) => Context.Orders.Where(o => o.CustomerId == customerId);

    public async Task<List<Order>> GetRecentOrdersAsync()
    {
        return await Context.Orders
            .OrderByDescending(order => order.OrderDate)
            .Take(5)
            .ToListAsync();
    }
    public async Task<decimal> GetTotalSalesAsync() => await Context.Orders
            .SumAsync(order => order.TotalAmount);

}