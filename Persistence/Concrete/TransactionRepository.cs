using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstract;

namespace Persistence.Concrete
{
    public class TransactionRepository : ITransactionRepository
    {
        private DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllByUserIDAsync(string userId)
        {
            return await _context.Transactions.Where(x => x.Portfolio.User.Id == userId).ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(int transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public void UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }

        public void DeleteAsync(Transaction transaction)
        {
            _context.Remove(transaction);
        }
    }
}