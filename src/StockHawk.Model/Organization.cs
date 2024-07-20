namespace StockHawk.Model;
public class Organization : BaseEntity
{
    public required string SID { get; set; } // Single identification (identifier to be used by users).
    public required string Name { get; set; }
    public ICollection<User> Users { get; set; } = default!;
}