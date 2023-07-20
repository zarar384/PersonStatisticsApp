using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data;
public interface IDataStore
{
    BaseDto AddOrUpdate(BaseDto dto);
    BaseDto Delete(int id);
    BaseDto Get(int id);
    BaseDto Get(string name);
    IEnumerable<BaseDto> GetAll();

}
