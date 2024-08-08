namespace StockHawk.Model;

public class Order : BaseEntity
{
    public required string Reference { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal ShippingCost { get; set; }
    public decimal TotalAmount { get; set; }


    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = default!;
    public int OrderTypeId { get; set; }
    public OrderType OrderType { get; set; } = default!;

    public ICollection<OrderItem> OrderItems { get; set; } = default!;
}