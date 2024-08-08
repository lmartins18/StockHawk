using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class OrderTypeRepository : BaseRepository<OrderType>, IOrderTypeRepository
{
    public OrderTypeRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override async Task<OrderType?> GetByIdAsync(int id)
        => await Context.Set<OrderType>()
            .Include(o => o.Orders)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);


    public override async Task<IEnumerable<OrderType>> GetAllAsync()
        => await Context.Set<OrderType>()
            .Where(p => !p.IsDeleted)
            .ToListAsync();

    public override async Task DeleteAsync(OrderType entity)
    {
        var orderType = await GetByIdAsync(entity.Id);
        if (orderType != null)
        {
            orderType.IsDeleted = true;
            await UpdateAsync(orderType);
        }
    }
}