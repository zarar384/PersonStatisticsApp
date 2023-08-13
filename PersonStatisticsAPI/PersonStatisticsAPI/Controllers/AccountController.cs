using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Interfaces;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.Models.Models;
using System.Net;

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
        public async Task<IActionResult> Register( RegisterDto user)
        {
            HttpModelResult result = new HttpModelResult();
            result = await _userManager.IsExists(user);

            if (result.HttpStatus == HttpStatusCode.BadRequest)
            {
                return BadRequest("Username is taken");
            }

            result = await _userManager.Add(user);
            if(result.HttpStatus == HttpStatusCode.Created) 
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
    }
}
