using CasualShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL
{
    public class EFDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        //For Migrations
        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Data Source=HOTTABYCH\\SQLEXPRESS;Initial Catalog=HomemadeKitchenDB;Integrated Security=True", b => b.MigrationsAssembly("HomemadeKitchen.DAL"));

                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}
