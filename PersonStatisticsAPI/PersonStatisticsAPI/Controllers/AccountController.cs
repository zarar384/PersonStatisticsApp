using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Interfaces;
using PersonStatisticsAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace PersonStatisticsAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        // private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName))
                return BadRequest("Username is taken");

            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var userDto = _mapper.Map<User, UserDto>(user);
                var roleResult = _userManager.AddToRoleAsync(user, "Member");

                if (!roleResult.IsCompleted) return BadRequest(result.Errors);

                userDto.Token = _tokenService.CreateToken(user);

                return new CreatedResult(string.Format("/api/register/{0}",
                                         userDto.Id),
                                         userDto);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            //using var hmac = new HMACSHA512(user.PasswordSalt);

            //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized("Invalid password");

            //for (int i = 0; i < computedHash.Length; i++)
            //{
            //    if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            //}

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
            };

            return new CreatedResult(string.Format("/api/register/{0}",
                                     user.Id),
                                     userDto);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username);
        }
    }
}
