using Domain.Entities;

namespace Application.Communication.EntityResponses
{
    public class PortfolioResponse : BaseResponse<Portfolio>
    {
        public PortfolioResponse(bool success) : base(success) { }
        public PortfolioResponse(Portfolio portfolio) : base(portfolio) { }
        public PortfolioResponse(string message) : base(message) { }
    }
}