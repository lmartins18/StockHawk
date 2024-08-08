namespace StockHawk.Service.DTOs;

public class SummaryDto
{
    public int TotalOrders { get; set; }
    public int TotalProducts { get; set; }
    public int TotalCategories { get; set; }
    public List<ProductDto> LowStockProducts { get; set; } = [];
    public List<ProductDto> OutOfStockProducts { get; set; } = [];
    public decimal TotalSales { get; set; }
    public List<OrderDto> RecentOrders { get; set; } = [];
}
