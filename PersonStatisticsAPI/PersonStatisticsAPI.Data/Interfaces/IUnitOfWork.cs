using PersonStatisticsAPI.Data.Interfaces;

namespace PersonStatisticsAPI.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IBoxRepository BoxRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
