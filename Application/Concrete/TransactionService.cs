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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string entName = "transaction";

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllByUserIDAsync(string userId)
        {
            return await _transactionRepository.GetAllByUserIDAsync(userId);
        }

        public async Task<TransactionResponse> GetOneAsync(int transactionId)
        {
            try
            {
                var transaction = await _transactionRepository.GetByIdAsync(transactionId);

                if (transaction == null)
                    return new TransactionResponse(false, new NotFoundMessage(entName).Message);

                return new TransactionResponse(transaction);
            }
            catch (Exception e)
            {
                return new TransactionResponse(false, new ErrorMessage(
                    CrudActions.Getting.ToString(),
                    entName,
                    e.Message).Message);
            }
        }

        public async Task<TransactionResponse> AddAsync(Transaction transaction)
        {
            try
            {
                await _transactionRepository.AddAsync(transaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(transaction);
            }
            catch (Exception e)
            {
                return new TransactionResponse(false, new ErrorMessage(
                    CrudActions.Saving.ToString(),
                    entName, e.Message).Message);
            }
        }

        public async Task<TransactionResponse> UpdateAsync(Transaction transaction)
        {
            try
            {
                var existing = await _transactionRepository.GetByIdAsync(transaction.Id);
                if (existing == null)
                    return new TransactionResponse(false, new NotFoundMessage(entName).Message);
                
                //TODO map properties here.

                _transactionRepository.UpdateAsync(existing);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(transaction);
            }
            catch (Exception e)
            {
                return new TransactionResponse(false, new ErrorMessage(
                    CrudActions.Updating.ToString(),
                    entName, e.Message).Message);
            }
        }

        public async Task<TransactionResponse> DeleteAsync(Transaction transaction)
        {
            try
            {
                var transactionToDelete = await _transactionRepository.GetByIdAsync(transaction.Id);

                if (transactionToDelete == null)
                    return new TransactionResponse(false, new NotFoundMessage(entName).Message);
                
                _transactionRepository.DeleteAsync(transactionToDelete);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(true);
            }
            catch (Exception e)
            {
                return new TransactionResponse(false, new ErrorMessage(
                    CrudActions.Deleting.ToString(),
                    entName, e.Message).Message);
            }
        }
    }
}