using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class CreateSupplierDto
{
    public required string Name { get; set; }

    [Phone]
    public required string ContactNumber { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public required string Email { get; set; }
    public required string Address { get; set; }
}