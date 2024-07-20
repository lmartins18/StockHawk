using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockHawk.Model;

namespace StockHawk.DataAccess;

public class StockHawkDbContext(IConfiguration configuration) : DbContext
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<Supplier> Suppliers { get; set; }
    public required DbSet<Customer> Customers { get; set; }
    public required DbSet<Order> Orders { get; set; }
    public required DbSet<OrderItem> OrderItems { get; set; }
    public required DbSet<ActivityLog> ActivityLogs { get; set; }
    public required DbSet<Organization> Organization { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product - Category relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Product - Supplier relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - Customer relationship
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - OrderStatus relationship
        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrderStatus)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.OrderStatusId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - OrderType relationship
        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrderType)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.OrderTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        // OrderItem - Order relationship
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // ActivityLog - User relationship
        modelBuilder.Entity<ActivityLog>()
            .HasOne(al => al.User)
            .WithMany()
            .HasForeignKey(al => al.UserId);

        modelBuilder.Entity<ActivityLog>()
            .HasOne(al => al.Order) // Optional One-to-Many relationship with Order (nullable)
            .WithMany() // Many ActivityLogs can be related to one Order
            .HasForeignKey(al => al.OrderId)
            .OnDelete(DeleteBehavior.SetNull); // Set OrderId to null if Order is deleted

        modelBuilder.Entity<Customer>()
            // One-to-Many relationship between Customer and Order
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer) // Optional: Configure foreign key property on Order
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            // One-to-Many relationship between Customer and Order
            .HasOne(c => c.Customer)
            .WithMany(o => o.Orders) // Optional: Configure foreign key property on Order
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            // One-to-Many relationship between Customer and Order
            .HasMany(c => c.OrderItems)
            .WithOne(o => o.Order) // Optional: Configure foreign key property on Order
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderItem>()
            // One-to-Many relationship between Customer and Order
            .HasOne(c => c.Order)
            .WithMany(o => o.OrderItems) // Optional: Configure foreign key property on Order
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            // One-to-Many relationship between Customer and Order
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(c => c.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Organization)
            .WithMany(o => o.Users)
            .HasForeignKey(u => u.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}