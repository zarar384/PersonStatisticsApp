using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Extensions;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.Models.Models;

namespace PersonStatisticsAPI.Data.Db
{
    public class AppliacationDbContext : DbContext
    {
        public AppliacationDbContext(DbContextOptions<AppliacationDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>() 
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(t => t.Name);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}