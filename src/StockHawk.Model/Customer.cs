namespace StockHawk.Model;
public class Customer : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public ICollection<Order> Orders { get; set; } = default!;
}
