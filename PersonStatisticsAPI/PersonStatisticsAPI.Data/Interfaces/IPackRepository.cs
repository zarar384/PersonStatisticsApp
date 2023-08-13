using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data.Interfaces;
public interface IPackRepository
{
    PackDto AddOrUpdate(PackDto dto);
    PackDto Delete(int id);
    PackDto Get(int id);
    PackDto Get(string name);
    IEnumerable<PackDto> GetAll();

}
