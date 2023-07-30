using AutoMapper;
using MediaBrowser.Model.Dto;
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
        private readonly ITokenService _tokenService;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, IUserManager userManager, IMapper mapper)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            HttpModelResult result = new HttpModelResult();
            result = await _userManager.IsExists(user);

            if (result.HttpStatus == HttpStatusCode.BadRequest)
            {
                return BadRequest("Username is taken");
            }

            result = _userManager.Add(user);
            if(result.HttpStatus == HttpStatusCode.Created) 
            {
                return new CreatedResult(string.Format("/api/register/{0}", 
                                         result.Model.Id), 
                                         result.Model);
            }

            return new StatusCodeResult((int)result.HttpStatus);
        }
    }
}
