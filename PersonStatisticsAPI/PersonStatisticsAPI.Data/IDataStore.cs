using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data;
public interface IDataStore
{
    BaseDto AddOrUpdate(BaseDto dto);
    BaseDto Delete(Guid id);
    BaseDto Get(Guid id);
    BaseDto Get(string name);
    IEnumerable<BaseDto> GetAll();

}
