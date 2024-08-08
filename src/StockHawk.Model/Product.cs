namespace StockHawk.Model;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
    public required int LowStockThreshold { get; set; }
    public required int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public required int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = default!;
    public ICollection<OrderItem> OrderItems { get; set; } = default!;
}