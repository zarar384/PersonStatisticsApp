using Microsoft.AspNetCore.Identity;

namespace PersonStatisticsAPI.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
