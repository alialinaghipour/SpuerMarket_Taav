using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class SalesFactor:Entity<int>
    {
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
