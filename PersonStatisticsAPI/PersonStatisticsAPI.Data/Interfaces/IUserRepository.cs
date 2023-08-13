using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStatisticsAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string login);
        Task<UserDto> Get(int id);
        Task<UserDto> Get(string login);
        Task<UserDto> Post(RegisterDto userDto);
    }
}
