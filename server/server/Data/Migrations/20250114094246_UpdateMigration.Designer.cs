﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Models;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(ServerDbContext))]
    [Migration("20250114094246_UpdateMigration")]
    partial class UpdateMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EmailAddress = "john.doe@example.com",
                            FullName = "John Doe",
                            PasswordHash = "password123",
                            Role = 0,
                            UserName = "johndoe"
                        },
                        new
                        {
                            UserId = 2,
                            EmailAddress = "jane.smith@example.com",
                            FullName = "Jane Smith",
                            PasswordHash = "password123",
                            Role = 1,
                            UserName = "janesmith"
                        });
                });

            modelBuilder.Entity("server.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Electronics",
                            Description = "Electronic devices"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Clothing",
                            Description = "Fashion and clothing"
                        });
                });

            modelBuilder.Entity("server.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            InvoiceDate = new DateTime(2025, 1, 14, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(695),
                            OrderId = 1,
                            TotalAmount = 400m
                        },
                        new
                        {
                            InvoiceId = 2,
                            InvoiceDate = new DateTime(2025, 1, 13, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(697),
                            OrderId = 2,
                            TotalAmount = 1100m
                        });
                });

            modelBuilder.Entity("server.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderDate = new DateTime(2025, 1, 14, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(630),
                            Status = 0,
                            TotalAmount = 400m,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            OrderDate = new DateTime(2025, 1, 13, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(645),
                            Status = 1,
                            TotalAmount = 1100m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("server.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Price = 400m,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Price = 1100m,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("server.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NewPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OldPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ImagePath = "/images/smartphone.jpg",
                            NewPrice = 400m,
                            OldPrice = 500m,
                            ProductDescription = "Latest model smartphone",
                            ProductName = "Smartphone",
                            StockQuantity = 100
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ImagePath = "/images/laptop.jpg",
                            NewPrice = 1100m,
                            OldPrice = 1200m,
                            ProductDescription = "High-performance laptop",
                            ProductName = "Laptop",
                            StockQuantity = 50
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ImagePath = "/images/tshirt.jpg",
                            NewPrice = 15m,
                            OldPrice = 20m,
                            ProductDescription = "Cotton t-shirt",
                            ProductName = "T-shirt",
                            StockQuantity = 200
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
