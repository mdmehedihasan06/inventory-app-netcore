using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using INVENTORY.Domain.Entities;
using INVENTORY.Domain.Entities.Account;
using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Domain.Entities.Settings;

namespace INVENTORY.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Account
        public DbSet<User> Users { get; set; }

        // Settings
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<KamAreaMapping> KamAreaMappings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

        // Sales
        public DbSet<SalesOrderMaster> SalesOrderMaster { get; set; }
        public DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderCost> SalesOrderCost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account
            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.Id);

            // Settings
            modelBuilder.Entity<Region>().ToTable("Regions").HasKey(u => u.Id);
            modelBuilder.Entity<Territory>().ToTable("Territories").HasKey(u => u.Id);
            modelBuilder.Entity<Area>().ToTable("Areas").HasKey(u => u.Id);
            modelBuilder.Entity<KamAreaMapping>().ToTable("KamAreaMappings").HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().ToTable("Customers").HasKey(u => u.Id);
            modelBuilder.Entity<Supplier>().ToTable("Suppliers").HasKey(u => u.Id);
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(u => u.Id);
            modelBuilder.Entity<ProductBrand>().ToTable("ProductBrands").HasKey(u => u.Id);
            modelBuilder.Entity<ProductModel>().ToTable("ProductModels").HasKey(u => u.Id);
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories").HasKey(u => u.Id);
            modelBuilder.Entity<ProductSubCategory>().ToTable("ProductSubCategories").HasKey(u => u.Id);
            modelBuilder.Entity<UnitOfMeasurement>().ToTable("UnitOfMeasurements").HasKey(u => u.Id);

            // Sales
            modelBuilder.Entity<SalesOrderMaster>().ToTable("SalesOrderMaster").HasKey(u => u.Id);
            modelBuilder.Entity<SalesOrderDetails>().ToTable("SalesOrderDetails").HasKey(u => u.Id);
            modelBuilder.Entity<SalesOrderCost>().ToTable("SalesOrderCost").HasKey(u => u.Id);

            // Model Builder Configuration
            modelBuilder.ApplyConfiguration(new SalesOrderDetailsConfiguration());

        }
    }
}
