using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(StockHawkDbContext context) : base(context) { }
}
