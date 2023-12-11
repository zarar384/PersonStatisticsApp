using AutoMapper;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;
using System.Net;

namespace PersonStatisticsAPI.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<HttpModelResult> Add(RegisterDto registerDto)
        {
            HttpModelResult result = new HttpModelResult();
            if (await _userRepository.GetUserAsync(registerDto.UserName) == null)
            {
                var userDto = await _userRepository.Post(registerDto);
                if (userDto != null)
                {

                    var user = _mapper.Map<UserDto, User>(userDto);
                    result.HttpStatus = HttpStatusCode.Created;
                    result.Model = user;
                }
            }
            else
            {
                result.HttpStatus = HttpStatusCode.Conflict;
                return result;
            }

            return result;
        }

        public async Task<HttpModelResult> Get(int id)
        {
            HttpModelResult result = new HttpModelResult();
            UserDto userDto = await _userRepository.GetMemberAsync(id);

            if (userDto == null)
            {
                result.HttpStatus = HttpStatusCode.BadRequest;
            }
            else
            {
                result.HttpStatus = HttpStatusCode.OK;
                result.Model = _mapper.Map<User>(userDto);
            }

            return result;
        }

        public async Task<HttpModelResult> Get(string username)
        {
            HttpModelResult result = new HttpModelResult();
            User user = await _userRepository.GetUserAsync(username);

            if (user == null)
            {
                result.HttpStatus = HttpStatusCode.BadRequest;
            }
            else
            {
                result.HttpStatus = HttpStatusCode.OK;
                result.Model = _mapper.Map<User>(user);
            }

            return result;
        }

        public async Task<HttpModelResult> IsExists(RegisterDto registerDto)
        {
            HttpModelResult result = new HttpModelResult();
            if (await _userRepository.UserExists(registerDto.UserName))
            {
                //Username is taken
                result.HttpStatus = HttpStatusCode.BadRequest;
                return result;
            }
            result.HttpStatus = HttpStatusCode.OK;
            return result;
        }
    }
}
