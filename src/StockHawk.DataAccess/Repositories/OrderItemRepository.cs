using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class OrderItemRepository : BaseRepository<OrderItem>
{
    public OrderItemRepository(StockHawkDbContext context) : base(context) { }
}
