using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SupeMarket.Persistence.EF
{
    public class EFDataContext:DbContext
    {
        public EFDataContext()
        {

        }

        public EFDataContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductEntry> ProductEntries { get; set; }
        public DbSet<SalesFactor> SalesFactors { get; set; }

    }
}
