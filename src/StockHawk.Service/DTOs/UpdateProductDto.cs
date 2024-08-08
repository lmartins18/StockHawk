using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class UpdateProductDto
{
    public required int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int? Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int? LowStockThreshold { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int? CategoryId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int? SupplierId { get; set; }
}