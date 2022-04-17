using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Abstract
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAllAsync();
        public Task<IEnumerable<Transaction>> GetAllByUserIDAsync(string userId);
        public Task<Transaction> GetByIdAsync(int transactionId);
        public Task AddAsync(Transaction transaction);
        public void UpdateAsync(Transaction transaction);
        public void DeleteAsync(Transaction transaction);
    }
}