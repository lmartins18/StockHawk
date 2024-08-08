namespace StockHawk.Service.DTOs;

public class OrderItemProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public required string CategoryName { get; set; }
    public required string SupplierName { get; set; }
}