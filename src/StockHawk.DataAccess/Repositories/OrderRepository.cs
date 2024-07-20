using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(StockHawkDbContext context) : base(context) { }

    // Additional order-specific methods can be implemented here
    public IEnumerable<Order> GetOrdersByCustomer(int customerId)
    => Context.Orders.Where(o => o.CustomerId == customerId);

}
