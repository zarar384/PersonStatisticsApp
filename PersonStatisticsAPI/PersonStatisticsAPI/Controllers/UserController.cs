using AutoMapper;
using MediaBrowser.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Extensions;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.Models.Models;
using System.Net;

namespace PersonStatisticsAPI.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            HttpModelResult result = new HttpModelResult();

            if (string.IsNullOrEmpty(User.GetUsername())) return NotFound("User not found");

            result = await _userManager.Get(id);

            if(result.HttpStatus== HttpStatusCode.BadRequest)
            {
                return BadRequest("User is not found");
            }

            if(result.HttpStatus== HttpStatusCode.OK)
            {
                var userModel = _mapper.Map<BaseModel, User>(result.Model);
                var userDto = _mapper.Map<User, UserDto>(userModel);

                return new CreatedResult(string.Format("/api/user/{0}", 
                                         result.Model.Id), 
                                         userDto);
            }

            return Ok(result);
        }

    }
}
