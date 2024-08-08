namespace StockHawk.Service.DTOs;

public class UpdateCategoryDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}