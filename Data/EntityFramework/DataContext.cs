using AirlineCompany.Modals;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Data.EntityFramework
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
          options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=AirlineCompanyDB;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyUser>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Flight>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<UserFlight>()
                .HasKey(b => b.Id);
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CompanyUser> Users { get; set; }
        public DbSet<UserFlight> UserFlights { get; set; }
    }
}
