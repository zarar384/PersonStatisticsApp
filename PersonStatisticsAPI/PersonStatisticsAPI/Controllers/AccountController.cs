using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Interfaces;
using PersonStatisticsAPI.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PersonStatisticsAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(IUserManager userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            HttpModelResult result = new HttpModelResult();
            result = await _userManager.IsExists(user);

            if (result.HttpStatus == HttpStatusCode.BadRequest)
            {
                return BadRequest("Username is taken");
            }

            result = await _userManager.Add(user);
            if (result.HttpStatus == HttpStatusCode.Created)
            {
                var userModel = _mapper.Map<BaseModel, User>(result.Model);
                var userDto = _mapper.Map<User, UserDto>(userModel);
                userDto.Token = _tokenService.CreateToken(userModel);

                return new CreatedResult(string.Format("/api/register/{0}",
                                         result.Model.Id),
                                         userDto);
            }

            return new StatusCodeResult((int)result.HttpStatus);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var userBase = await _userManager.Get(loginDto.Username);

            if (userBase.HttpStatus == HttpStatusCode.BadRequest) return Unauthorized("Invalid username");

            var user = _mapper.Map<User>(userBase.Model);
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = _tokenService.CreateToken(user),
            };

            return new CreatedResult(string.Format("/api/register/{0}",
                                     user.Id),
                                     userDto);
        }
    }
}
