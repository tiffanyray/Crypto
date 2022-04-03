using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Abstract
{
    public interface IPortfolioRepository
    {
        public Task<IEnumerable<Portfolio>> GetAllAsync();
        public Task<IEnumerable<Portfolio>> GetAllByUserIDAsync(string userId);
        public Task<Portfolio> FindByIdAsync(int portfolioId);
        public Task AddAsync(Portfolio portfolio);
        public void UpdateAsync(Portfolio portfolio);
        public void DeleteAsync(Portfolio portfolio);
    }
}