namespace StockHawk.Service.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public required string Reference { get; set; }
    public required string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderOrderStatusDto OrderStatus { get; set; } = default!;
    public OrderOrderTypeDto OrderType { get; set; } = default!;
    public ICollection<OrderOrderItemDto> OrderItems { get; set; } = default!;
}