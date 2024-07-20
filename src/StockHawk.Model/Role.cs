namespace StockHawk.Model;
public class Role : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ICollection<User> Users { get; set; } = default!;
}