namespace StockHawk.Model;
public class Supplier : BaseEntity
{
    public required string Name { get; set; }
    public required string ContactNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public ICollection<Product> Products { get; set; } = default!;
}
