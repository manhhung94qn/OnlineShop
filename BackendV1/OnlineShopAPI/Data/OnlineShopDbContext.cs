using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
        {

        }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ProductFeedback> ProductFeedback { get; set; }
        public DbSet<ProductRate> ProductRate { get; set; }
        public DbSet<ProductSpecification> ProductSpecification { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-A5OQKG2\SQLEXPRESS;Database=OnlineShop;Trusted_Connection=True;");

            }
        }
    }
}
