using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data.Db
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<Role>()
            {
                new Role(){Name="Member"},
                new Role(){Name="BoxCreator"},
                new Role(){Name="Moderator"},
                new Role(){Name="Admin"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new User
            {
                UserName = "IceArthas",
            };

            await userManager.CreateAsync(admin, "OnePiece1$Real");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
        }
    }
}
