using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Extensions;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
            //modelBuilder.Entity<User>().Ignore(t => t.Name);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<BoxItem> BoxItems { get; set; }
        public DbSet<BoxRecipient> BoxRecipients { get; set; }
        public DbSet<ItemRating> ItemRatings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TransfersLog> TransfersLogs { get; set; }
    }
}