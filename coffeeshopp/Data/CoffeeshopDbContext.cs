using coffeeshopp.Models;
using Microsoft.EntityFrameworkCore;

namespace coffeeshopp.Data
{
    public class CoffeeshopDbContext : DbContext
    {
        public CoffeeshopDbContext(DbContextOptions<CoffeeshopDbContext> options) : base(options)
        {
        }

        // Tạo bảng Products trong cơ sở dữ liệu
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        // Khởi tạo dữ liệu mẫu (Seed Data) vào CSDL
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "America", Price = 25, Detail = "Name product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = true },
                new Product { Id = 2, Name = "Vietnam", Price = 20, Detail = "Vietnamese product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = true },
                new Product { Id = 3, Name = "United Kingdom", Price = 15, Detail = "UK product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = false },
                new Product { Id = 4, Name = "India", Price = 15, Detail = "India product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = false },
                new Product { Id = 5, Name = "Russian", Price = 25, Detail = "Russian product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = true },
                new Product { Id = 6, Name = "France", Price = 35, Detail = "France product", ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", IsTrendingProduct = false }
            );
        }
    }
}