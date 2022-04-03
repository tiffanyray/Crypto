using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Abstract
{
    public interface IUserRepository
    {
        public Task<User> GetByEmail(string email);
        public Task<User> GetByUsername(string userName);
        public Task<bool> UserExistsByEmail(string email);
        public Task<bool> UserExistsByUsername(string userName);
    }
}