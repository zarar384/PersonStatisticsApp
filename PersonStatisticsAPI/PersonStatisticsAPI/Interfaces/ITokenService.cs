using PersonStatisticsAPI.Models.Models;

namespace PersonStatisticsAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
