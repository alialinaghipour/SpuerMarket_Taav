using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class ProductEntry:Entity<int>
    {
        public string ProdcutCode { get; set; }
        public int Count { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
