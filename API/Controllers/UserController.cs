using System.Threading.Tasks;
using API.RequestDtos;
using API.ResponseDtos;
using Application.Abstract;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserResponse>> Login(UserLoginRequest request)
        {
            var mapUser = _mapper.Map<UserLoginRequest, User>(request);
            var response = await _userService.Login(mapUser);
            if (!response.Success)
                return BadRequest(response.Message);

            var mapResponse = _mapper.Map<User, UserResponse>(response.Resource);
            return Ok(mapResponse);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserResponse>> Register(UserRegisterRequest request)
        {
            var mapUser = _mapper.Map<UserRegisterRequest, User>(request);
            var response = await _userService.Register(mapUser);
            if (!response.Success)
                return BadRequest(response.Message);
            var mapResponse = _mapper.Map<User, UserResponse>(response.Resource);
            return Ok(mapResponse);
        }
        
        [HttpGet]
        [Route("emailexists")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> EmailExists(string email)
        {
            return Ok(await _userService.UsernameExists(email));
        }
    }
}