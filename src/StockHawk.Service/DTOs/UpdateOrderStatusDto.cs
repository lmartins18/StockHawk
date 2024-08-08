namespace StockHawk.Service.DTOs;

public class UpdateOrderStatusDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}