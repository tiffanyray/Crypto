namespace API.ResponseDtos
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CryptoId { get; set; }
        public decimal? CoinQuantity { get; set; }
        public decimal? UsdPrice { get; set; }
        public decimal? CoinPrice { get; set; }
    }
}