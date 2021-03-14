using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public class AddProductEntryDto
    {
        public string ProdcutCode { get; set; }
        [Min(1)]
        public int Count { get; set; }
    }
}
