using System;

namespace SuperMarket.Services.SalesFactories
{
    public class GetByIdSalesFactoryDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public DateTime SalesDate { get; set; }
    }
}