using HRManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HRManager.API.Persistence
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
