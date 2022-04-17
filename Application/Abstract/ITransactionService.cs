using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Communication.EntityResponses;
using Domain.Entities;

namespace Application.Abstract
{
    public interface ITransactionService
    {
        public Task<IEnumerable<Transaction>> GetAllAsync();
        public Task<IEnumerable<Transaction>> GetAllByUserIDAsync(string userId);
        public Task<TransactionResponse> GetOneAsync(int transactionId);
        public Task<TransactionResponse> AddAsync(Transaction transaction);
        public Task<TransactionResponse> UpdateAsync(Transaction transaction);
        public Task<TransactionResponse> DeleteAsync(Transaction transaction);
    }
}