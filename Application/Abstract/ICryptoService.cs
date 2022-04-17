using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Communication.EntityResponses;
using Domain.Entities;

namespace Application.Abstract
{
    public interface ICryptoService
    {
        public Task<List<Crypto>> GetAll();
        public Task<CryptoResponse> GetById(int id);
        public Task<CryptoResponse> GetByName(string name);
        public Task<CryptoResponse> CreateAsync(Crypto crypto);
        public Task<CryptoResponse> Update(Crypto crypto);
        public Task<CryptoResponse> Delete(Crypto crypto);
    }
}