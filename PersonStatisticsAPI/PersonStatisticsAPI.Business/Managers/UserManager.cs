using AutoMapper;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;
using System.Net;

namespace PersonStatisticsAPI.Business.Managers
{
    internal class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public HttpModelResult Add(BaseModel baseModel)
        {
            HttpModelResult result = new HttpModelResult();
            if(_userRepository.Get(baseModel.Name) == null)
            {
                //TODO Create
            }
            else
            {
                result.HttpStatus = HttpStatusCode.Conflict;
                return result;
            }

            return result;
        }

        public async Task<HttpModelResult> IsExists(BaseModel user)
        {
            HttpModelResult result = new HttpModelResult();
            UserDto userDto = _mapper.Map<BaseModel, UserDto>(user);
            if (await _userRepository.UserExists(userDto.Login)) 
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
