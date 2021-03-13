using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
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

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductEntry> ProductEntries { get; set; }
        public DbSet<SalesFactor> SalesFactors { get; set; }

    }
}
