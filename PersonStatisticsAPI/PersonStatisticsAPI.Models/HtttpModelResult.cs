using System.Net;

namespace PersonStatisticsAPI.Models
{
    public class HttpModelResult
    {
        public HttpStatusCode HttpStatus { get; set; }
        public BaseModel Model { get; set; }
        public IEnumerable<BaseModel> Models { get; set; }
    }
}
