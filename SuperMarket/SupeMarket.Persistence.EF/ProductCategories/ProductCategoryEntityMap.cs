using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF.ProductCategories
{
    public class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Tilte).IsRequired().HasMaxLength(40);

            builder.HasMany(_ => _.Products)
                .WithOne(_ => _.ProductCategory)
                .HasForeignKey(_ => _.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
