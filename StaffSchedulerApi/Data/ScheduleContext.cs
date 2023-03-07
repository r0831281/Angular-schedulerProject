using Microsoft.EntityFrameworkCore;
using StaffSchedulerApi.Models;

namespace StaffSchedulerApi.Data
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<AvailableDate> availableDates { get; set; }
        public DbSet<RequestedDate> requestedDate { get; set; }
        public DbSet<PlannedDate> plannedDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<AvailableDate>().ToTable("availableDates");
            modelBuilder.Entity<RequestedDate>().ToTable("requestedDates");
            modelBuilder.Entity<PlannedDate>().ToTable("plannedDates");

            modelBuilder.Entity<User>().Property(u => u.RoleId).HasDefaultValue(1);

        }
    }
}
