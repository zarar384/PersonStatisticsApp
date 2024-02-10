using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Extensions;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data.Db
{
    public class AppDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<BoxRecipient>()
                .HasKey(k => new { k.BoxId, k.RecipientId});

            builder.Entity<BoxRecipient>()
                .HasOne(s => s.Box)
                .WithMany(t => t.Recipients)
                .HasForeignKey(s => s.BoxId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<BoxItem> BoxItems { get; set; }
        public DbSet<BoxRecipient> BoxRecipients { get; set; }
        //public DbSet<ItemRating> ItemRatings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        //public DbSet<TransfersLog> TransfersLogs { get; set; }
    }
}