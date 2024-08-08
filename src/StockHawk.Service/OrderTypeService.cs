using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.Service;

public class OrderTypeService : IOrderTypeService
{
    private readonly IOrderTypeRepository _orderTypeRepository;
    private readonly IMapper _mapper;

    public OrderTypeService(IOrderTypeRepository orderTypeRepository, IMapper mapper)
    {
        _orderTypeRepository = orderTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderTypeDto>> GetAllOrderTypesAsync()
    {
        var orderTypes = await _orderTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderTypeDto>>(orderTypes);
    }

    public async Task<OrderTypeDto?> GetOrderTypeByIdAsync(int id)
    {
        var orderType = await _orderTypeRepository.GetByIdAsync(id);
        return _mapper.Map<OrderTypeDto?>(orderType);
    }

    public async Task<OrderTypeDto> AddOrderTypeAsync(CreateOrderTypeDto createOrderTypeDto)
    {
        var existingOrderType = (await _orderTypeRepository.GetAllAsync())
          .FirstOrDefault(c => c.Name.Equals(createOrderTypeDto.Name, StringComparison.OrdinalIgnoreCase));

        if (existingOrderType != null)
        {
            throw new DuplicateEntityException($"An order type with this name already exists.");
        }

        var orderType = _mapper.Map<OrderType>(createOrderTypeDto);
        await _orderTypeRepository.AddAsync(orderType);
        return _mapper.Map<OrderTypeDto>(orderType);
    }

    public async Task<OrderTypeDto?> UpdateOrderTypeAsync(UpdateOrderTypeDto updateOrderTypeDto)
    {
        var orderType = await _orderTypeRepository.GetByIdAsync(updateOrderTypeDto.Id);

        if (orderType == null) return null;

        // Check if another order type with the same name already exists
        var existingOrderType = (await _orderTypeRepository.GetAllAsync())
            .FirstOrDefault(c => c.Name.Equals(updateOrderTypeDto.Name, StringComparison.OrdinalIgnoreCase) && c.Id != updateOrderTypeDto.Id);

        if (existingOrderType != null)
        {
            throw new DuplicateEntityException($"An order type with this name already exists.");
        }

        // Apply updates from DTO to entity
        _mapper.Map(updateOrderTypeDto, orderType);

        await _orderTypeRepository.UpdateAsync(orderType);
        return _mapper.Map<OrderTypeDto>(orderType);
    }

    public async Task<bool?> DeleteOrderTypeAsync(int id)
    {
        var orderType = await _orderTypeRepository.GetByIdAsync(id);
        if (orderType == null) return null;

        var hasOrders = orderType.Orders?.Count > 0;
        if (hasOrders) return false;

        await _orderTypeRepository.DeleteAsync(orderType);
        return true;
    }
}
