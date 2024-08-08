using System.ComponentModel.DataAnnotations;

namespace StockHawk.Service.DTOs;

public class CreateCustomerDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public required string Email { get; set; }
    [Phone]
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
}