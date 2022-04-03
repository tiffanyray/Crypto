using System.Threading.Tasks;
using Application.Abstract;
using Application.Communication.EntityResponses;
using Application.Security;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.Abstract;

namespace Application.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }
        
        public async Task<UserResponse> Register(User user)
        {
            if (await _userRepository.UserExistsByEmail(user.Email))
                return new UserResponse(false, "User already exist with this email. Please use a different email.");

            if (await _userRepository.UserExistsByUsername(user.UserName))
                return new UserResponse(false, "Username already taken. Please try a different username.");

            var results = await _userManager.CreateAsync(user);
            if (results.Succeeded)
            {
                // TODO: Decide on a user response object that includes a token and we will have to send that here
                return new UserResponse(true, "Success");
            }

            return new UserResponse(false);
        }
    }
}