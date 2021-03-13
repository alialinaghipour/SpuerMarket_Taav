using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class ProductCategory:Entity<int>
    {
        public string Tilte { get; set; }
        public List<Product> Products { get; set; }
    }
}
