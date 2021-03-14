using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF.SalesFactories
{
    public class SalesFactoryEntityMap : IEntityTypeConfiguration<SalesFactor>
    {
        public void Configure(EntityTypeBuilder<SalesFactor> builder)
        {
            builder.ToTable("SalesFactors");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.ProductCode).IsRequired().HasMaxLength(10);

            builder.Property(_ => _.Count).IsRequired();

            builder.Property(_ => _.SalesDate).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
