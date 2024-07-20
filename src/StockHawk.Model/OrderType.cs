namespace StockHawk.Model;

public class OrderType : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Order> Orders { get; set; } = default!;
}