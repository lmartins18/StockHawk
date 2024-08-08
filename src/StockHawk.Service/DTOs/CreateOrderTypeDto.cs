namespace StockHawk.Service.DTOs;

public class CreateOrderTypeDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}