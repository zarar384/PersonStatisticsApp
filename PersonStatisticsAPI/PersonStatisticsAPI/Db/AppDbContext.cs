using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Roleplayer> Roleplayers { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

    }
}