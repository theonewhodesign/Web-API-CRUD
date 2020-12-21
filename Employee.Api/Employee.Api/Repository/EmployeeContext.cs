using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Repository
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
