using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine.DBClasses
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MagazineUser> Users { get; set; } = null!;
        public DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StatusOrder> OrderStatuses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        private static DatabaseContext instance;
        private DatabaseContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=InternetMagazine.db;");
        }
        public static DatabaseContext GetDB()
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new DatabaseContext();
                return instance;
            }
        }
    }
}
