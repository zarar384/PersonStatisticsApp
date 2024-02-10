using Microsoft.AspNetCore.Identity;
using PersonStatisticsAPI.Models.Extensions;
using System.Text.Json.Serialization;

namespace PersonStatisticsAPI.Models
{
    public class User : IdentityUser<int>
    {
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
