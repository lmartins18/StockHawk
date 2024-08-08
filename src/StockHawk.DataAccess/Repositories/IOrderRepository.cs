using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    IEnumerable<Order> GetOrdersByCustomer(int customerId);
    Task<List<Order>> GetRecentOrdersAsync();
    Task<decimal> GetTotalSalesAsync();
    Task<IEnumerable<Order>> GetAllWithOrderItemsAsync();
}