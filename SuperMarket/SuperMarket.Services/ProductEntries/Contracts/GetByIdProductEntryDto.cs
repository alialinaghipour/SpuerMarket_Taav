using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public class GetByIdProductEntryDto
    {
        public int Id { get; set; }
        public string ProdcutCode { get; set; }
        public int Count { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
