namespace StockHawk.Model;
public class ActivityLog : BaseEntity
{
    public int UserId { get; set; }
    public int? ProductId { get; set; } 
    public int? OrderId { get; set; } 
    public required string Action { get; set; }
    public required string Details { get; set; }
    public DateTime Timestamp { get; set; }

    public required User User { get; set; }
    public required Product Product { get; set; }
    public required Order Order { get; set; } 
}