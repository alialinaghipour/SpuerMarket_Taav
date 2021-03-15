﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Migrations.Migrations
{
    [Migration(20210314944)]
    public class _20210314944_InitialData : Migration
    {

        public override void Up()
        {
            Create.Table("WareHouses")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Count").AsInt32().Nullable()
                .WithColumn("Name").AsString().NotNullable();

            Create.Table("ProductCategories")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Tilte").AsString(50).NotNullable().Unique();

            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Code").AsString(10).NotNullable().Unique()
                .WithColumn("Count").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Price").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("MinimumInventory").AsInt32().NotNullable()
                .WithColumn("WareHouseId").AsInt32().NotNullable()
                     .ForeignKey("FK_Products_WareHouses", "WareHouses", "Id")
                .WithColumn("CategoryId").AsInt32().NotNullable()
                     .ForeignKey("FK_Products_ProductCategories", "ProductCategories", "Id");
                     //.OnDelete;

            Create.Table("ProductEntries")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProdcutCode").AsString(10).NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("EntryDate").AsDateTime().NotNullable();

            Create.Table("SalesFactors")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductCode").AsString(10).NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("SalesDate").AsDateTime().NotNullable();

            //Create.ForeignKey("FK_Products_ProductCategories")
            //      .FromTable("Products").ForeignColumn("CategoryId")
            //      .ToTable("ProductCategories").PrimaryColumn("Id")
            //      .OnDelete(System.Data.Rule.None);
        }
        public override void Down()
        {
            Delete.Table("ProductEntries");
            Delete.Table("SalesFactors");
            Delete.Table("Products");
            Delete.Table("WareHouses");
            Delete.Table("ProductCategories");
            //Delete.ForeignKey("FK_Products_ProductCategories");
        }
    }
}
