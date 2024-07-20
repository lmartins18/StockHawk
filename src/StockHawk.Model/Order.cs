namespace StockHawk.Model;
public class Order : BaseEntity
{
    public required string Reference { get; set; }
    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalAmount { get; set; }
    public int OrderStatusId { get; set; }
    public required OrderStatus OrderStatus { get; set; }
    public int OrderTypeId { get; set; }
    public required OrderType OrderType { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = default!;
}
