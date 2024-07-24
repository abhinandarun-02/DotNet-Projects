using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var employeeOne = new Employee { EmployeeId=1, Name="Abhinand", Department="Dev"};
            var employeeTwo = new Employee { EmployeeId=2, Name="John", Department="QA"};

            modelBuilder.Entity<Employee>().HasData(employeeOne, employeeTwo);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
