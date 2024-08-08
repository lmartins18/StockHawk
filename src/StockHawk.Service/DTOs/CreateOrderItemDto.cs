using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class CreateOrderItemDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int ProductId { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required decimal Quantity { get; set; }
}