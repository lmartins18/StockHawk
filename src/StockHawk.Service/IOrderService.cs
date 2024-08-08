using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto);
    Task<int?> DeleteOrderAsync(int id);
    Task<IEnumerable<OrderDto>> GetOrdersByCustomerAsync(int customerId);
    Task<OrderDto?> UpdateOrderAsync(UpdateOrderDto updateOrderDto);
    Task<int> GetOrderCountAsync();
    Task<decimal> GetTotalSalesAsync();
    Task<List<OrderDto>> GetRecentOrdersAsync();
}