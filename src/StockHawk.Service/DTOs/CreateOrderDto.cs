using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class CreateOrderDto
{
    public required string Reference { get; init; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int CustomerId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
    public decimal ShippingCost { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
    public decimal TotalAmount { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int OrderStatusId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int OrderTypeId { get; set; }
    public required ICollection<CreateOrderItemDto> OrderItems { get; init; }
}