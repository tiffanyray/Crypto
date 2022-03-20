namespace API.RequestDtos
{
    public class PortfolioRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CryptoId { get; set; }
    }
}