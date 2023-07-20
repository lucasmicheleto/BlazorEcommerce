using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Data
{
    public class BlCommerceDataContext: DbContext
    {
        public BlCommerceDataContext(DbContextOptions<BlCommerceDataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, Title = "Apple iPhone 13", Description = "The latest iPhone model with 5G technology", ImageUrl = "https://fdn2.gsmarena.com/vv/bigpic/apple-iphone-13.jpg", Price = 799.00m },
            //    new Product { Id = 2, Title = "Samsung Galaxy S21", Description = "The latest Samsung Galaxy model with 5G technology", ImageUrl = "https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-s21-5g-r.jpg", Price = 799.99m },
            //    new Product
            //    {
            //        Id = 3,
            //        Title = "Google Pixel 6",
            //        Description = "The latest Google Pixel model with 5G technology",
            //        ImageUrl = "https://fdn2.gsmarena.com/vv/bigpic/google-pixel-6.jpg",
            //        Price = 699.00m
            //    }
            //);
        }

        public DbSet<Product> Products { get; set; }
    }
}
