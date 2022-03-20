using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstract;
using Application.Communication;
using Application.Communication.EntityResponses;
using Domain.Entities;
using Persistence.Abstract;

namespace Application.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string entName = "portfolio";

        public PortfolioService(IPortfolioRepository portfolioRepository, IUnitOfWork unitOfWork)
        {
            _portfolioRepository = portfolioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await _portfolioRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Portfolio>> GetAllByUserIDAsync(string userId)
        {
            return await _portfolioRepository.GetAllByUserIDAsync(userId);
        }

        public async Task<PortfolioResponse> GetOneAsync(int portfolioId)
        {
            try
            {
                var portfolio = await _portfolioRepository.FindByIdAsync(portfolioId);

                if (portfolio == null)
                    return new PortfolioResponse(new NotFoundMessage(entName).Message);

                return new PortfolioResponse(portfolio);
            }
            catch (Exception error)
            {
                return new PortfolioResponse(new ErrorMessage(
                    CrudActions.Getting.ToString(),
                    entName,
                    error.Message
                ).Message);
            }
        }

        public async Task<PortfolioResponse> SaveAsync(Portfolio portfolio)
        {
            try
            {
                await _portfolioRepository.AddAsync(portfolio);
                await _unitOfWork.CompleteAsync();

                return new PortfolioResponse(portfolio);
            }
            catch (Exception error)
            {
                return new PortfolioResponse(new ErrorMessage(
                    CrudActions.Saving.ToString(),
                    entName,
                    error.Message
                ).Message);
            }
        }

        public async Task<PortfolioResponse> UpdateAsync(Portfolio portfolio)
        {
            try
            {
                var existing = await _portfolioRepository.FindByIdAsync(portfolio.Id);
                if (existing == null)
                    return new PortfolioResponse(new NotFoundMessage(entName).Message);

                existing.Name = portfolio.Name;
                existing.Description = portfolio.Description;
                // TODO: Add validation for crypto before now??
                existing.Crypto = portfolio.Crypto;
                // We never want to update the user.
                
                _portfolioRepository.UpdateAsync(existing);
                _unitOfWork.CompleteAsync();

                return new PortfolioResponse(existing);
            }
            catch (Exception error)
            {
                return new PortfolioResponse(new ErrorMessage(
                    CrudActions.Updating.ToString(),
                    entName,
                    error.Message
                ).Message);
            }
        }

        public async Task<PortfolioResponse> DeleteAsync(int portfolioId)
        {
            try
            {
                var existing = await _portfolioRepository.FindByIdAsync(portfolioId);
                if (existing == null)
                    return new PortfolioResponse(new NotFoundMessage(entName).Message);

                _portfolioRepository.DeleteAsync(existing);
                _unitOfWork.CompleteAsync();
                return new PortfolioResponse(true);
            }
            catch (Exception error)
            {
                return new PortfolioResponse(new ErrorMessage(
                    CrudActions.Deleting.ToString(),
                    entName,
                    error.Message
                ).Message);
            }
        }
    }
}