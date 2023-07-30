using PersonStatisticsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStatisticsAPI.Business.Interfaces
{
    public interface IUserManager
    {
        Task<HttpModelResult> IsExists(BaseModel baseModel);
        HttpModelResult Add(BaseModel baseModel);
    }
}
