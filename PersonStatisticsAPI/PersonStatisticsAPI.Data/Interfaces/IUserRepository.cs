using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;

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
