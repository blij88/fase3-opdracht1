using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.Entities;

namespace PhoneShop.Business.Data
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, BrandId = 1, Price = 54, Stock = 12, Description = "testing", Type = "test1" },
                new Phone { Id = 2, BrandId = 2, Price = 54, Stock = 12, Description = "testing", Type = "test2" },
                new Phone { Id = 3, BrandId = 1, Price = 54, Stock = 12, Description = "testing", Type = "test3" },
                new Phone { Id = 4, BrandId = 2, Price = 54, Stock = 12, Description = "testing", Type = "test4" },
                new Phone { Id = 5, BrandId = 1, Price = 54, Stock = 12, Description = "testing", Type = "test5" }
                );
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Motorola" },
                new Brand { Id = 2, Name = "Xiaomi" }
                );
        }
    }
}
