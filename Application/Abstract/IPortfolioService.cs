using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Communication;
using Application.Communication.EntityResponses;
using Domain.Entities;

namespace Application.Abstract
{
    public interface IPortfolioService
    {
        public Task<IEnumerable<Portfolio>> GetAllAsync();
        public Task<PortfolioResponse> GetOneAsync(int portfolioId);
        public Task<PortfolioResponse> SaveAsync(Portfolio portfolio);
        public Task<PortfolioResponse> UpdateAsync(Portfolio portfolio);
        public Task<PortfolioResponse> DeleteAsync(int portfolioId);
    }
}