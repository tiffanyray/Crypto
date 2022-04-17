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
    public class CryptoService : ICryptoService
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string entName = "crypto";

        public CryptoService(ICryptoRepository cryptoRepository, IUnitOfWork unitOfWork)
        {
            _cryptoRepository = cryptoRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<List<Crypto>> GetAll()
        {
            return await _cryptoRepository.GetAllAsync();
        }

        public async Task<CryptoResponse> GetById(int id)
        {
            try
            {
                var crypto = await _cryptoRepository.GetOneById(id);
                if (crypto == null)
                    return new CryptoResponse(false, new NotFoundMessage(entName).Message);

                return new CryptoResponse(crypto);
            }
            catch (Exception e)
            {
                return new CryptoResponse(false, new ErrorMessage(
                    CrudActions.Getting.ToString(), entName, e.Message).Message);
            }
        }

        public async Task<CryptoResponse> GetByName(string name)
        {
            try
            {
                var crypto = await _cryptoRepository.GetOneByName(name);
                if (crypto == null)
                    return new CryptoResponse(false, new NotFoundMessage(entName).Message);
                
                return new CryptoResponse(crypto);
            }
            catch (Exception e)
            {
                return new CryptoResponse(false, new ErrorMessage(
                    CrudActions.Getting.ToString(), entName, e.Message).Message);
            }
        }

        public async Task<CryptoResponse> CreateAsync(Crypto crypto)
        {
            try
            {
                var existing = _cryptoRepository.GetOneByName(crypto.Name);
                if (existing != null)
                    return new CryptoResponse(false, entName + " already exist ");

                await _cryptoRepository.AddAsync(crypto);
                await _unitOfWork.CompleteAsync();

                return new CryptoResponse(crypto);
            }
            catch (Exception e)
            {
                return new CryptoResponse(false, new ErrorMessage(
                    CrudActions.Saving.ToString(), entName, e.Message).Message);
            }
        }

        public async Task<CryptoResponse> Update(Crypto crypto)
        {
            try
            {
                var existing = _cryptoRepository.GetOneByName(crypto.Name);
                if (existing != null)
                    return new CryptoResponse(false, entName + " already exist ");

                // TODO: add entity mapping
                
                
                _cryptoRepository.UpdateAsync(crypto);
                await _unitOfWork.CompleteAsync();

                return new CryptoResponse(crypto);
            }
            catch (Exception e)
            {
                return new CryptoResponse(false, new ErrorMessage(
                    CrudActions.Updating.ToString(), entName, e.Message).Message);
            }
        }

        public async Task<CryptoResponse> Delete(Crypto crypto)
        {
            try
            {
                var existing = _cryptoRepository.GetOneByName(crypto.Name);
                if (existing != null)
                    return new CryptoResponse(false, entName + " already exist ");

                _cryptoRepository.Delete(crypto);
                await _unitOfWork.CompleteAsync();

                return new CryptoResponse(crypto);
            }
            catch (Exception e)
            {
                return new CryptoResponse(false, new ErrorMessage(
                    CrudActions.Deleting.ToString(), entName, e.Message).Message);
            }
        }
    }
}