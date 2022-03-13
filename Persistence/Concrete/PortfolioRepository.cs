using System.Collections.Generic;
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
            return await _context.Portfolios.AsNoTracking().ToListAsync();
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