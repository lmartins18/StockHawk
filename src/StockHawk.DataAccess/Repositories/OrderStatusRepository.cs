using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class OrderStatusRepository : BaseRepository<OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override async Task<OrderStatus?> GetByIdAsync(int id)
        => await Context.Set<OrderStatus>()
            .Include(o => o.Orders)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);


    public override async Task<IEnumerable<OrderStatus>> GetAllAsync()
        => await Context.Set<OrderStatus>()
            .Where(p => !p.IsDeleted)
            .ToListAsync();

    public override async Task DeleteAsync(OrderStatus entity)
    {
        var orderStatus = await GetByIdAsync(entity.Id);
        if (orderStatus != null)
        {
            orderStatus.IsDeleted = true;
            await UpdateAsync(orderStatus);
        }
    }
}