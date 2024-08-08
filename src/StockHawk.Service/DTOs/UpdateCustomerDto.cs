using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class UpdateCustomerDto
{
    public required int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}