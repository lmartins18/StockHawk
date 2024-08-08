using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface IOrderTypeService
{
    Task<IEnumerable<OrderTypeDto>> GetAllOrderTypesAsync();
    Task<OrderTypeDto?> GetOrderTypeByIdAsync(int id);
    Task<OrderTypeDto> AddOrderTypeAsync(CreateOrderTypeDto createOrderTypeDto);
    Task<OrderTypeDto?> UpdateOrderTypeAsync(UpdateOrderTypeDto updateOrderTypeDto);
    Task<bool?> DeleteOrderTypeAsync(int id);
}