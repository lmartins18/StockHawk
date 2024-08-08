namespace StockHawk.Service.DTOs;

public class OrderOrderTypeDto // TO be used for orderDto only
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

}