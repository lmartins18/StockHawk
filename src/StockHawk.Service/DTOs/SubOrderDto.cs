namespace StockHawk.Service.DTOs;

public class SubOrderDto // To be used exclusive as dependency to avoid circular dependecy
{
    public int Id { get; set; }
    public required string Reference { get; set; }
    public required string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<OrderOrderItemDto> OrderItems { get; set; } = default!;
}