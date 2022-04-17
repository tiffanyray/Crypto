using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstract;

namespace Persistence.Concrete
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly DataContext _context;

        public CryptoRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<Crypto>> GetAllAsync()
        {
            return await _context.Cryptos.ToListAsync();
        }

        public async Task<Crypto> GetOneById(int id)
        {
            return await _context.Cryptos.FindAsync(id);
        }

        public async Task<Crypto> GetOneByName(string name)
        {
            return await _context.Cryptos.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task AddAsync(Crypto crypto)
        {
            await _context.Cryptos.AddAsync(crypto);
        }

        public void UpdateAsync(Crypto crypto)
        {
            _context.Cryptos.Update(crypto);
        }

        public void Delete(Crypto crypto)
        {
            _context.Cryptos.Remove(crypto);
        }
    }
}