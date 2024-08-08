using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.Service;

public class OrderStatusService : IOrderStatusService
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderStatusDto>> GetAllOrderStatusesAsync()
    {
        var orderStatuses = await _orderStatusRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderStatusDto>>(orderStatuses);
    }

    public async Task<OrderStatusDto?> GetOrderStatusByIdAsync(int id)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(id);
        return _mapper.Map<OrderStatusDto?>(orderStatus);
    }

    public async Task<OrderStatusDto> AddOrderStatusAsync(CreateOrderStatusDto createOrderStatusDto)
    {
        var existingOrderStatus = (await _orderStatusRepository.GetAllAsync())
          .FirstOrDefault(c => c.Name.Equals(createOrderStatusDto.Name, StringComparison.OrdinalIgnoreCase));

        if (existingOrderStatus != null)
        {
            throw new DuplicateEntityException($"An order status with this name already exists.");
        }

        var orderStatus = _mapper.Map<OrderStatus>(createOrderStatusDto);
        await _orderStatusRepository.AddAsync(orderStatus);
        return _mapper.Map<OrderStatusDto>(orderStatus);
    }

    public async Task<OrderStatusDto?> UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(updateOrderStatusDto.Id);

        if (orderStatus == null) return null;

        // Check if another order status with the same name already exists
        var existingOrderStatus = (await _orderStatusRepository.GetAllAsync())
            .FirstOrDefault(c => c.Name.Equals(updateOrderStatusDto.Name, StringComparison.OrdinalIgnoreCase) && c.Id != updateOrderStatusDto.Id);

        if (existingOrderStatus != null)
        {
            throw new DuplicateEntityException($"An order status with this name already exists");
        }

        // Apply updates from DTO to entity
        _mapper.Map(updateOrderStatusDto, orderStatus);

        await _orderStatusRepository.UpdateAsync(orderStatus);
        return _mapper.Map<OrderStatusDto>(orderStatus);
    }

    public async Task<bool?> DeleteOrderStatusAsync(int id)
    {
        var orderStatus = await _orderStatusRepository.GetByIdAsync(id);

        if (orderStatus == null) return null;

        var hasOrders = orderStatus.Orders?.Count > 0;
        if (hasOrders) return false;

        await _orderStatusRepository.DeleteAsync(orderStatus);
        return true;
    }
}