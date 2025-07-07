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

        public DbSet<Category> Categories { get; set; }
        public DbSet<product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "茶飲", DisplayOrder = 1 },
               new Category { Id = 2, Name = "咖啡", DisplayOrder = 2 },
               new Category { Id = 3, Name = "甜點", DisplayOrder = 3 },
               new Category { Id = 4, Name = "小吃", DisplayOrder = 4 }
               );
            modelBuilder.Entity<product>().HasData(
                new product
                {
                    Id = 1,
                    Name = "台灣水果茶",
                    Size = "大杯",
                    Description = "天然果飲,迷人多變 ",
                    price = 60
                },
           new product
           {
               Id = 2,
               Name = "鐵觀音",
               Size = "中杯",
               Description = "品鐵觀音,享人生的味道",
               price = 35
           },
           new product
           {
               Id = 3,
               Name = "美式咖啡",
               Size = "中杯",
               Description = "用咖啡體悟悠閒時光",
               price = 50
           }
           );
        }
    }
}