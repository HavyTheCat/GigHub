using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using GigHub.Core.Models;

namespace GigHub.Persistence
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityConfigurations.GigConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.AttendanceConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.FollowingConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.GenreConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.UserNotificationConfiguration());
          


            base.OnModelCreating(modelBuilder);
        }

    }
}