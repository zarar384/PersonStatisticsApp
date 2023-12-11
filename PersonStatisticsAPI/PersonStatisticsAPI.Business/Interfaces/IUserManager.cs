using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Business.Interfaces
{
    public interface IUserManager
    {
        Task<HttpModelResult> IsExists(RegisterDto baseModel);
        Task<HttpModelResult> Get (int id);
        Task<HttpModelResult> Get(string name);
        Task<HttpModelResult> Add(RegisterDto baseModel);
    }
}
