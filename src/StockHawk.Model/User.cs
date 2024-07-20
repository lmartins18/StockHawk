namespace StockHawk.Model;
public class User : BaseEntity
{
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; } = default!;
}