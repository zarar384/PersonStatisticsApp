using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data.Db
{
    public class AppliacationDbContext : DbContext
    {
        public AppliacationDbContext(DbContextOptions<AppliacationDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
        }

        public DbSet<Person> Persons { get; set; }
    }
}