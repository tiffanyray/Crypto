using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Abstract
{
    public interface ICryptoRepository
    {
        public Task<List<Crypto>> GetAllAsync();
        public Task<Crypto> GetOneById(int id);
        public Task<Crypto> GetOneByName(string name);
        public Task AddAsync(Crypto crypto);
        public void UpdateAsync(Crypto crypto);
        public void Delete(Crypto crypto);
    }
}