using Microsoft.EntityFrameworkCore;
using StaffSchedulerApi.Models;

namespace StaffSchedulerApi.Data
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }
        public DbSet<RequestedDate> RequestedDate { get; set; }
        public DbSet<PlannedDate> PlannedDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<User>().ToTable("users");
 
            modelBuilder.Entity<AvailableDate>().ToTable("availableDates");
            modelBuilder.Entity<RequestedDate>().ToTable("requestedDates");
            modelBuilder.Entity<PlannedDate>().ToTable("plannedDates");

            modelBuilder.Entity<User>().Property(u => u.RoleId).HasDefaultValue(1);

        }
    }
}
