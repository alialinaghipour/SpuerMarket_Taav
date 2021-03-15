using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class WareHouse:Entity<int>
    {
        public WareHouse()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public int? Count { get; set; }

        public HashSet<Product> Products { get; set; }
    }
}
