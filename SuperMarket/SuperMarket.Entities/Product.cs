using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class Product:Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int MinimumInventory { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public int WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
