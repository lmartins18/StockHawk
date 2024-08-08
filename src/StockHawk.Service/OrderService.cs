using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.Utilities;

namespace StockHawk.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderTypeRepository _orderTypeRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository,
        ICustomerRepository customerRepository, IOrderTypeRepository orderTypeRepository,
        IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderTypeRepository = orderTypeRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto)
    {
        // Check if OrderItems and product IDs are provided
        if (createOrderDto.OrderItems == null || !createOrderDto.OrderItems.Any())
        {
            throw new ArgumentException("Order must contain at least one order item.");
        }

        var productIds = createOrderDto.OrderItems.Select(oi => oi.ProductId).Distinct().ToList();
        var customerId = createOrderDto.CustomerId;
        var orderTypeId = createOrderDto.OrderTypeId;
        var orderStatusId = createOrderDto.OrderStatusId;
        var orderDate = createOrderDto.OrderDate.Date;

        // Fetch products if product IDs are not null or empty
        List<Product> products = new();
        if (productIds.Any())
        {
            products = await _productRepository.GetByIdsAsync(productIds);
        }

        // Fetch the related entities (Customer, OrderType, OrderStatus)
        Customer? customer = await _customerRepository.GetByIdAsync(customerId);
        OrderType? orderType = await _orderTypeRepository.GetByIdAsync(orderTypeId);
        OrderStatus? orderStatus = await _orderStatusRepository.GetByIdAsync(orderStatusId);
        // Get all orders to ensure it's not duplicate
        IEnumerable<Order> orders = await _orderRepository.GetAllAsync();

        // Throw an exception if any of the related entities is null
        if (customer == null)
        {
            throw new ArgumentException($"Customer with ID {customerId} not found.");
        }

        if (orderType == null)
        {
            throw new ArgumentException($"OrderType with ID {orderTypeId} not found.");
        }

        if (orderStatus == null)
        {
            throw new ArgumentException($"OrderStatus with ID {orderStatusId} not found.");
        }

        // Check if order with same reference exists
        var existingRef = orders.FirstOrDefault(o => o.Reference.Equals(createOrderDto.Reference, StringComparison.OrdinalIgnoreCase));
        if (existingRef != null)
        {
            throw new DuplicateEntityException("An order with this reference already exists");
        }

        // Check if an order with the same customer and date already exists
        var existingOrder = orders.FirstOrDefault(o => o.CustomerId == customerId && o.OrderDate.Date == orderDate);
        if (existingOrder != null)
        {
            throw new DuplicateEntityException("An order for this customer has already been placed on this date.");
        }

        var order = _mapper.Map<Order>(createOrderDto);

        // Set the related entities
        order.Customer = customer;
        order.OrderType = orderType;
        order.OrderStatus = orderStatus;

        // Populate the OrderItems with the actual Product entities and validate stock availability
        foreach (var orderItem in order.OrderItems)
        {
            var product = products.FirstOrDefault(p => p.Id == orderItem.ProductId);
            if (product != null)
            {
                if (product.Quantity < orderItem.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient stock for product with ID {product.Id}. Available: {product.Quantity}, Required: {orderItem.Quantity}");
                }
                orderItem.Product = product;
                // Update the stock quantity
                product.Quantity -= orderItem.Quantity;
                await _productRepository.UpdateAsync(product); // Update each product individually
            }
            else
            {
                throw new ArgumentException($"Product with ID {orderItem.ProductId} not found.");
            }
        }

        // Add the order to the repository
        await _orderRepository.AddAsync(order);

        // Return the mapped OrderDto
        return _mapper.Map<OrderDto>(order);
    }




    public async Task<int?> DeleteOrderAsync(int id)
    {
        // TODO: after an order has been processed, it should not be able to be deleted.
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null) return null;

        await _orderRepository.DeleteAsync(order);
        return id;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerAsync(int customerId)
    {
        var orders = await Task.Run(() => _orderRepository.GetOrdersByCustomer(customerId));
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
    {
        var order = await _orderRepository.GetByIdAsync(updateOrderDto.Id);

        if (order is null) return null;

        UpdateHelper.ApplyUpdates(updateOrderDto, order);

        var orderStatus = await _orderStatusRepository.GetByIdAsync(updateOrderDto.OrderStatusId);
        if (orderStatus != null)
        {
            order.OrderStatus = orderStatus;
        }
        else
        {
            throw new ArgumentException("Invalid OrderStatusId.");
        }

        await _orderRepository.UpdateAsync(order);

        return _mapper.Map<OrderDto>(order);
    }
    public async Task<int> GetOrderCountAsync()
    {
        return await _orderRepository.CountAsync();
    }

    public async Task<decimal> GetTotalSalesAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Sum(order => order.TotalAmount);
    }

    public async Task<List<OrderDto>> GetRecentOrdersAsync()
    {
        List<Order> recentOrders = await _orderRepository.GetRecentOrdersAsync();
        return _mapper.Map<List<OrderDto>>(recentOrders);
    }

}