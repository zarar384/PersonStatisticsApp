using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
