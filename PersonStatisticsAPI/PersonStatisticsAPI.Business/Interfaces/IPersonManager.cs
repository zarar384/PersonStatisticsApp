using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Business.Interfaces;
public interface IPersonManager
{
    HttpModelResult  Add(BaseModel model);
    HttpModelResult Update(BaseModel model, int id);
    HttpModelResult Get(int id);
    HttpModelResult Delete(int id);
    HttpModelResult GetAll();
}
