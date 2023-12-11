using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data.Interfaces;
public interface IBoxRepository
{
    BoxDto AddOrUpdate(BoxDto dto);
    BoxDto Delete(int id);
    BoxDto Get(int id);
    BoxDto Get(string name);
    IEnumerable<BoxDto> GetAll();

}
