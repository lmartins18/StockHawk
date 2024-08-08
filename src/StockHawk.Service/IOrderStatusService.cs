using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface IOrderStatusService
{
    Task<IEnumerable<OrderStatusDto>> GetAllOrderStatusesAsync();
    Task<OrderStatusDto?> GetOrderStatusByIdAsync(int id);
    Task<OrderStatusDto> AddOrderStatusAsync(CreateOrderStatusDto createOrderStatusDto);
    Task<OrderStatusDto?> UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto);
    Task<bool?> DeleteOrderStatusAsync(int id);
}