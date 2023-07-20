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

        public DbSet<Person> Persons { get; set; }
    }
}