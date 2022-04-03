using System.Threading.Tasks;
using Application.Communication.EntityResponses;
using Domain.Entities;

namespace Application.Abstract
{
    public interface IUserService
    {
        public Task<UserResponse> Register(User user);
    }
}