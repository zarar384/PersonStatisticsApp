using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models.Models;
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
        Task<UserDto> GetMemberAsync(int id);
        Task<User> GetUserAsync(string username);
        Task<UserDto> GetMemberAsync(string username);
        Task<UserDto> Post(RegisterDto userDto);
    }
}
