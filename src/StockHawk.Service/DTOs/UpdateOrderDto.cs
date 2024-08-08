using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class UpdateOrderDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int Id { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
    public required int OrderStatusId { get; set; }
}