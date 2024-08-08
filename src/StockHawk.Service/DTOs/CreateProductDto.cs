using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public int LowStockThreshold { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int CategoryId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int SupplierId { get; set; }
}