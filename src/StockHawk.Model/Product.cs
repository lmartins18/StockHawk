namespace StockHawk.Model;
public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int LowStockThreshold { get; set; }
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;
    public ICollection<OrderItem> OrderItems { get; set; } = default!;
}
