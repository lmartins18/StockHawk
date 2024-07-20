namespace StockHawk.Model;
public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ICollection<Product> Products { get; set; } = default!;
}
