using EmployeePortal.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data for employess
            var employessData = new List<Employee>
            {
                new Employee
                {
                    Id=Guid.Parse("0681be5c-f2b2-4eec-b444-c6f1eb4b7f7d"),
                    Name="Jhon",
                    Email="jhon@gmail.com",
                    PhoneNumber="1234567891",
                    Salary=0
                },
                 new Employee
                {
                    Id=Guid.Parse("b6e6f70c-ad32-48c3-911e-3e55ac5e9b23"),
                    Name="Sena",
                    Email="Sena@gmail.com",
                    PhoneNumber=null,
                    Salary=0
                },
                  new Employee
                {
                    Id=Guid.Parse("5d80b3f5-de5b-4cdc-8d43-940239834594"),
                    Name="JhonWick",
                    Email="JhonWick@gmail.com",
                    PhoneNumber=null,
                    Salary=0
                }
            };
            modelBuilder.Entity<Employee>().HasData(employessData);
        }

        
    }
}
