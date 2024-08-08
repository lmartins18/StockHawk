namespace StockHawk.Service.DTOs;

public class OrderStatusDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<SubOrderDto> Orders { get; set; } = default!;
}
