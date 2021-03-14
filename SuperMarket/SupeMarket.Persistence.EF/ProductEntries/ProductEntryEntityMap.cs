using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF.ProductEntries
{
    public class ProductEntryEntityMap : IEntityTypeConfiguration<ProductEntry>
    {
        public void Configure(EntityTypeBuilder<ProductEntry> builder)
        {
            builder.ToTable("ProductEntries");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.ProdcutCode).IsRequired().HasMaxLength(10);

            builder.Property(_ => _.Count).IsRequired();

            builder.Property(_ => _.EntryDate).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
