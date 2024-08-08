namespace StockHawk.Service.DTOs;

/// <summary>
/// DTO made exclusively for OrderItems that are part of an OrderDto
/// </summary>
public class OrderOrderItemDto
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal Quantity { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal TotalPrice => Quantity * ProductPrice;
}
