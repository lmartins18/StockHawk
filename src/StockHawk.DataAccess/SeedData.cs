using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // OrderStatuses
            var orderStatuses = new[]
            {
                new OrderStatus { Id = 1, Name = "Pending", Description = "Order is pending" },
                new OrderStatus { Id = 2, Name = "Shipped", Description = "Order has been shipped" },
                new OrderStatus { Id = 3, Name = "Delivered", Description = "Order has been delivered" },
                new OrderStatus { Id = 4, Name = "Cancelled", Description = "Order has been cancelled" }
            };
            modelBuilder.Entity<OrderStatus>().HasData(orderStatuses);

            // OrderTypes
            var orderTypes = new[]
            {
                new OrderType { Id = 1, Name = "Retail", Description = "Retail order" },
                new OrderType { Id = 2, Name = "Wholesale", Description = "Wholesale order" }
            };
            modelBuilder.Entity<OrderType>().HasData(orderTypes);

            // Categories
            var categories = new[]
            {
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = 2, Name = "Home Appliances", Description = "Appliances for home use" },
                new Category { Id = 3, Name = "Books", Description = "Books of various genres" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // Suppliers
            var suppliers = new[]
            {
                new Supplier
                {
                    Id = 1, Name = "Supplier1", ContactNumber = "1234567890", Email = "supplier1@example.com",
                    Address = "123 Supplier St"
                },
                new Supplier
                {
                    Id = 2, Name = "Supplier2", ContactNumber = "0987654321", Email = "supplier2@example.com",
                    Address = "456 Supplier Ave"
                },
                new Supplier // Supplier with no products
                {
                    Id = 3, Name = "Empty supplier", ContactNumber = "123123123", Email = "supplier3@example.com",
                    Address = "322 Supplier Ave"
                }
            };
            modelBuilder.Entity<Supplier>().HasData(suppliers);

            // Products
            var products = new[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "Latest model smartphone",
                    Price = 699.99m,
                    Quantity = 50,
                    LowStockThreshold = 10,
                    CategoryId = categories[0].Id,
                    SupplierId = suppliers[0].Id,
                },
                new Product
                {
                    Id = 2,
                    Name = "Washing Machine",
                    Description = "High-efficiency washing machine",
                    Price = 499.99m,
                    Quantity = 30,
                    LowStockThreshold = 5,
                    CategoryId = categories[1].Id,
                    SupplierId = suppliers[1].Id,
                },
                new Product
                {
                    Id = 3,
                    Name = "Novel",
                    Description = "Bestselling novel",
                    Price = 19.99m,
                    Quantity = 100,
                    LowStockThreshold = 20,
                    CategoryId = categories[2].Id,
                    SupplierId = suppliers[1].Id,
                }
            };
            modelBuilder.Entity<Product>().HasData(products);

            // Customers
            var customers = new[]
            {
                new Customer
                {
                    Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com",
                    PhoneNumber = "555-1234",
                    Address = "789 Customer Rd"
                },
                new Customer
                {
                    Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com",
                    PhoneNumber = "555-5678", Address = "321 Customer Blvd"
                }
            };
            modelBuilder.Entity<Customer>().HasData(customers);

            // Orders
            var orders = new[]
            {
                new Order
                {
                    Id = 1,
                    Reference = "ORD001",
                    OrderDate = DateTime.UtcNow.AddDays(-1),
                    ShippingCost = 10.00m,
                    TotalAmount = 709.99m,
                    CustomerId = customers[0].Id,
                    OrderStatusId = orderStatuses[0].Id,
                    OrderTypeId = orderTypes[0].Id
                },
                new Order
                {
                    Id = 2,
                    Reference = "ORD002",
                    OrderDate = DateTime.UtcNow,
                    ShippingCost = 15.00m,
                    TotalAmount = 515.00m,
                    CustomerId = customers[0].Id,
                    OrderStatusId = orderStatuses[0].Id,
                    OrderTypeId = orderTypes[0].Id
                }
            };
            modelBuilder.Entity<Order>().HasData(orders);

            // OrderItems
            var orderItems = new[]
            {
                new OrderItem
                {
                    Id = 1,
                    Quantity = 1,
                    DiscountAmount = 0.00m,
                    TotalAmount = 699.99m,
                    OrderId = orders[0].Id,
                    ProductId = products[0].Id
                },
                new OrderItem
                {
                    Id = 2,
                    Quantity = 1,
                    DiscountAmount = 0.00m,
                    TotalAmount = 499.99m,
                    OrderId = orders[0].Id,
                    ProductId = products[0].Id
                }
            };
            modelBuilder.Entity<OrderItem>().HasData(orderItems);
            
        }
    }
}