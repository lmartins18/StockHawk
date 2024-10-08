﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockHawk.DataAccess;

#nullable disable

namespace StockHawk.Migrations
{
    [DbContext(typeof(StockHawkDbContext))]
    [Migration("20240802133427_UpdateOrderItemRelationship2")]
    partial class UpdateOrderItemRelationship2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockHawk.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6010),
                            Description = "Electronic devices and gadgets",
                            IsDeleted = false,
                            Name = "Electronics",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6010)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020),
                            Description = "Appliances for home use",
                            IsDeleted = false,
                            Name = "Home Appliances",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020),
                            Description = "Books of various genres",
                            IsDeleted = false,
                            Name = "Books",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6030)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "789 Customer Rd",
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6160),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            PhoneNumber = "555-1234",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6160)
                        },
                        new
                        {
                            Id = 2,
                            Address = "321 Customer Blvd",
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6170),
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            IsDeleted = false,
                            LastName = "Smith",
                            PhoneNumber = "555-5678",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6170)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6190),
                            CustomerId = 1,
                            IsDeleted = false,
                            OrderDate = new DateTime(2024, 8, 1, 13, 34, 27, 343, DateTimeKind.Utc).AddTicks(6200),
                            OrderStatusId = 1,
                            OrderTypeId = 1,
                            Reference = "ORD001",
                            ShippingCost = 10.00m,
                            TotalAmount = 709.99m,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6200)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6210),
                            CustomerId = 1,
                            IsDeleted = false,
                            OrderDate = new DateTime(2024, 8, 2, 13, 34, 27, 343, DateTimeKind.Utc).AddTicks(6220),
                            OrderStatusId = 1,
                            OrderTypeId = 1,
                            Reference = "ORD002",
                            ShippingCost = 15.00m,
                            TotalAmount = 515.00m,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6210)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6240),
                            DiscountAmount = 0.00m,
                            IsDeleted = false,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            TotalAmount = 699.99m,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6240)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6250),
                            DiscountAmount = 0.00m,
                            IsDeleted = false,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            TotalAmount = 499.99m,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6250)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5720),
                            Description = "Order is pending",
                            IsDeleted = false,
                            Name = "Pending",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5810)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5820),
                            Description = "Order has been shipped",
                            IsDeleted = false,
                            Name = "Shipped",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5820)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5830),
                            Description = "Order has been delivered",
                            IsDeleted = false,
                            Name = "Delivered",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5830)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5840),
                            Description = "Order has been cancelled",
                            IsDeleted = false,
                            Name = "Cancelled",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5840)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980),
                            Description = "Retail order",
                            IsDeleted = false,
                            Name = "Retail",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980),
                            Description = "Wholesale order",
                            IsDeleted = false,
                            Name = "Wholesale",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5990)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LowStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6100),
                            Description = "Latest model smartphone",
                            IsDeleted = false,
                            LowStockThreshold = 10,
                            Name = "Smartphone",
                            Price = 699.99m,
                            Quantity = 50,
                            SupplierId = 1,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6110)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6120),
                            Description = "High-efficiency washing machine",
                            IsDeleted = false,
                            LowStockThreshold = 5,
                            Name = "Washing Machine",
                            Price = 499.99m,
                            Quantity = 30,
                            SupplierId = 2,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6120)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6130),
                            Description = "Bestselling novel",
                            IsDeleted = false,
                            LowStockThreshold = 20,
                            Name = "Novel",
                            Price = 19.99m,
                            Quantity = 100,
                            SupplierId = 2,
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6130)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Supplier St",
                            ContactNumber = "1234567890",
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6050),
                            Email = "supplier1@example.com",
                            IsDeleted = false,
                            Name = "Supplier1",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6060)
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Supplier Ave",
                            ContactNumber = "0987654321",
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6060),
                            Email = "supplier2@example.com",
                            IsDeleted = false,
                            Name = "Supplier2",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070)
                        },
                        new
                        {
                            Id = 3,
                            Address = "322 Supplier Ave",
                            ContactNumber = "123123123",
                            CreatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070),
                            Email = "supplier3@example.com",
                            IsDeleted = false,
                            Name = "Empty supplier",
                            UpdatedAt = new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070)
                        });
                });

            modelBuilder.Entity("StockHawk.Model.Order", b =>
                {
                    b.HasOne("StockHawk.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StockHawk.Model.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockHawk.Model.OrderType", "OrderType")
                        .WithMany("Orders")
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");

                    b.Navigation("OrderType");
                });

            modelBuilder.Entity("StockHawk.Model.OrderItem", b =>
                {
                    b.HasOne("StockHawk.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockHawk.Model.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StockHawk.Model.Product", b =>
                {
                    b.HasOne("StockHawk.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockHawk.Model.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("StockHawk.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StockHawk.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StockHawk.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("StockHawk.Model.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StockHawk.Model.OrderType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StockHawk.Model.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("StockHawk.Model.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
