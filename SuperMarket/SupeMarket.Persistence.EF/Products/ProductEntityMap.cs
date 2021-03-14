using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

            builder.Property(_ => _.Code).IsRequired().HasMaxLength(10);

            builder.Property(_ => _.Count).IsRequired().HasDefaultValue(0);

            builder.Property(_ => _.Price).IsRequired().HasDefaultValue(0);

            builder.Property(_ => _.CategoryId).IsRequired();

            builder.HasOne(_ => _.ProductCategory)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.CategoryId);
        }
    }
}
