using PersonStatisticsAPI.Models.Extensions;
using System.Text.Json.Serialization;

namespace PersonStatisticsAPI.Models.Models
{
    public class User: BaseModel
    {
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public Person Person { get; set; }
    }
}
