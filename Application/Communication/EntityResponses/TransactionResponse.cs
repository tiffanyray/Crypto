using Domain.Entities;

namespace Application.Communication.EntityResponses
{
    public class TransactionResponse : BaseResponse<Transaction>
    {
        public TransactionResponse(bool success): base(success) { }
        public TransactionResponse(Transaction transaction): base(transaction) { }
        public TransactionResponse(bool success, string message): base(success, message) { }
    }
}