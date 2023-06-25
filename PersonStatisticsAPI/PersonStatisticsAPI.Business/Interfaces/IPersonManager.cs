using PersonStatisticsAPI.Models;
using System.Web;

namespace PersonStatisticsAPI.Business.Interfaces;
public interface IPersonManager
{
    HttpModelResult Add(BaseModel model);
    HttpModelResult Update(BaseModel model, Guid id);
    HttpModelResult Get(Guid id);
    HttpModelResult Delete(Guid id);
    HttpModelResult GetAll();
}
