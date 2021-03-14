using DataAnnotationsExtensions;

namespace SuperMarket.Services.SalesFactories
{
    public class AddSalesFactorDto
    {
        public string ProductCode { get; set; }
        [Min(1)]
        public int Count { get; set; }
        public bool IsInformation { get; set; }
    }
}