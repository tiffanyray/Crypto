namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Crypto Crypto { get; set; }
        public decimal? CoinQuantity { get; set; }
        public decimal? UsdPrice { get; set; }
        public decimal? CoinPrice { get; set; }
    }
}