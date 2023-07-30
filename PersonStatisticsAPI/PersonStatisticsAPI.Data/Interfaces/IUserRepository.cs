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
        UserDto Get(int id);
        UserDto Get(string login);

    }
}
