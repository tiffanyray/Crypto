using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstract;

namespace Persistence.Concrete
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private DataContext _context;

        public PortfolioRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await _context.Portfolios.AsNoTracking().Include(x => x.Crypto).ToListAsync();
        }

        public async Task<IEnumerable<Portfolio>> GetAllByUserIDAsync(string userId)
        {
            return await _context.Portfolios.Where(x => x.User.Id == userId).ToListAsync();
        }

        public async Task<Portfolio> FindByIdAsync(int portfolioId)
        {
            return await _context.Portfolios.FindAsync(portfolioId);
        }

        public async Task AddAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
        }

        public void UpdateAsync(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
        }

        public void DeleteAsync(Portfolio portfolio)
        {
            _context.Portfolios.Remove(portfolio);
        }
    }
}