using Microsoft.EntityFrameworkCore;
using TeaTimeDomo.Models;

namespace TeaTimeDemo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public
            ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "茶飲", DisplayOrder = 1 },
               new Category { Id = 2, Name = "咖啡", DisplayOrder = 2 },
               new Category { Id = 3, Name = "甜點", DisplayOrder = 3 },
               new Category { Id = 4, Name = "小吃", DisplayOrder = 4 }
               );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "台灣水果茶",
                    Size = "大杯",
                    Description = "天然果飲,迷人多變 ",
                    Price = 60,
                    CategoryId = 1,
                    ImageUrl=""
                },
           new Product
           {
               Id = 2,
               Name = "鐵觀音",
               Size = "中杯",
               Description = "品鐵觀音,享人生的味道",
               Price = 35,
                CategoryId = 2,
               ImageUrl = ""
           },
           new Product
           {
               Id = 3,
               Name = "美式咖啡",
               Size = "中杯",
               Description = "用咖啡體悟悠閒時光",
               Price = 50,
               CategoryId = 3,
               ImageUrl = ""
           }
           );
        }
    }
}