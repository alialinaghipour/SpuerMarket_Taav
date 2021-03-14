using System;

namespace SuperMarket.Services.SalesFactories
{
    public class GetAllSalesFactoryDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public DateTime SalesDate { get; set; }
    }
}