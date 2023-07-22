using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Data.Interfaces;
public interface IPersonRepository
{
    PersonDto AddOrUpdate(PersonDto dto);
    PersonDto Delete(int id);
    PersonDto Get(int id);
    PersonDto Get(string name);
    IEnumerable<PersonDto> GetAll();

}
