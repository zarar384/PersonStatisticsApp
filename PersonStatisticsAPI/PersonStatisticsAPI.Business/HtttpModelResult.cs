using System.Net;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Business
{
    public class HttpModelResult
    {
        public HttpStatusCode HttpStatus { get; set; }
        public BaseModel Model { get; set; }
        public IEnumerable<BaseModel> Models { get; set; }
    }
}
