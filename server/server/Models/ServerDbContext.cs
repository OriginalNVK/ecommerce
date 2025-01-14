using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace server.Models
{
    public class ServerDbContext:DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "John Doe", UserName = "johndoe", EmailAddress = "john.doe@example.com", PasswordHash = "password123", Role = UserRole.Admin },
                new User { UserId = 2, FullName = "Jane Smith", UserName = "janesmith", EmailAddress = "jane.smith@example.com", PasswordHash = "password123", Role = UserRole.Client }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Electronics", Description = "Electronic devices" },
                new Category { CategoryID = 2, CategoryName = "Clothing", Description = "Fashion and clothing" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Smartphone", CategoryId = 1, OldPrice = 500, NewPrice = 400, ProductDescription = "Latest model smartphone", StockQuantity = 100, ImagePath = "/images/smartphone.jpg" },
                new Product { ProductId = 2, ProductName = "Laptop", CategoryId = 1, OldPrice = 1200, NewPrice = 1100, ProductDescription = "High-performance laptop", StockQuantity = 50, ImagePath = "/images/laptop.jpg" },
                new Product { ProductId = 3, ProductName = "T-shirt", CategoryId = 2, OldPrice = 20, NewPrice = 15, ProductDescription = "Cotton t-shirt", StockQuantity = 200, ImagePath = "/images/tshirt.jpg" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = DateTime.Now, UserId = 1, Status = OrderStatus.Pending, TotalAmount = 400 },
                new Order { OrderId = 2, OrderDate = DateTime.Now.AddDays(-1), UserId = 2, Status = OrderStatus.Approve, TotalAmount = 1100 }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 1, Price = 400 },
                new OrderDetail { OrderId = 2, ProductId = 2, Quantity = 1, Price = 1100 }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, OrderId = 1, InvoiceDate = DateTime.Now, TotalAmount = 400 },
                new Invoice { InvoiceId = 2, OrderId = 2, InvoiceDate = DateTime.Now.AddDays(-1), TotalAmount = 1100 }
            );
        }
    }
}
