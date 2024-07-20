namespace StockHawk.Model;
public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public required Order Order { get; set; }
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
}