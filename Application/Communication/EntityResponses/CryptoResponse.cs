using Domain.Entities;

namespace Application.Communication.EntityResponses
{
    public class CryptoResponse : BaseResponse<Crypto>
    {
        public CryptoResponse(bool success) : base(success) { }
        public CryptoResponse(Crypto crypto) : base(crypto) { }
        public CryptoResponse(bool success, string message) : base(success, message) { }
        
    }
}