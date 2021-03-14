namespace SuperMarket.Services.SalesFactories
{
    public class AddSalesFactorDto
    {
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public bool IsInformation { get; set; }
    }
}