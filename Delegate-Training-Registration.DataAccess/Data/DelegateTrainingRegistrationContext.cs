using Delegate_Training_Registration.DataAccess.Extensions;
using Delegate_Training_Registration.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Delegate_Training_Registration.DataAccess.Data
{
    public class DelegateTrainingRegistrationContext : DbContext
    {
        public DelegateTrainingRegistrationContext(DbContextOptions<DelegateTrainingRegistrationContext> options) : base(options)
        {
        }

        // tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<RegisteredTrainings> RegisteredTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure entities guid key prop to auto-generate.
            modelBuilder.Entity<Course>().Property(c => c.CourseCode).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Person>().Property(p => p.PersonID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PhysicalAddress>().Property(p => p.PhysicalAddressesID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<RegisteredTrainings>().Property(r => r.RegisteredTrainingsID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Training>().Property(t => t.TrainingID).HasDefaultValueSql("NEWID()");

            // seeding db with data.
            modelBuilder.Seed();
        }
    }
}
