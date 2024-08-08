namespace StockHawk.Service.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int LowStockThreshold { get; set; }
    public required CategoryDto Category { get; set; }
    public required SupplierDto Supplier { get; set; }
}