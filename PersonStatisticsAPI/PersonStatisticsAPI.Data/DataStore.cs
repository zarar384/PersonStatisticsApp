using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data;
public class DataStore : IDataStore
{
    List<BaseDto> _dtoRepository;

    public DataStore()
    {
        _dtoRepository = new List<BaseDto>();
    }

    public BaseDto AddOrUpdate(BaseDto dto)
    {
        if (dto.Id == null)
        {
            _dtoRepository.Add(dto);
        }
        else
        {
            _dtoRepository.Remove(dto);
            _dtoRepository.Add(dto);
        }

        return dto;
    }

    public BaseDto Delete(int id)
    {
        BaseDto baseDto = _dtoRepository.Find(x => x.Id == id);
        if (baseDto != null)
        {
            _dtoRepository.Remove(baseDto);
            return baseDto;
        }
        else
        {
            return null;
        }
    }

    public BaseDto Get(int id)
    {
        return _dtoRepository.FirstOrDefault(x => x.Id == id);
    }

    public BaseDto Get(string name)
    {
        return _dtoRepository.FirstOrDefault(x => x.Name == name);
    }

    public IEnumerable<BaseDto> GetAll()
    {
        return _dtoRepository;
    }
}
