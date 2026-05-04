using EmployeePortal.Data;
using EmployeePortal.Data.Domain;
using EmployeePortal.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;

        public SQLEmployeeRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee CreateEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee? DeleteEmployee(Guid id)
        {
            var existingEmployee = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }
            dbContext.Employees.Remove(existingEmployee);
            dbContext.SaveChanges();
            return existingEmployee;
        }

        public List<Employee> GetAll()
        {
            return dbContext.Employees.ToList();
        }

        public Employee? GetById(Guid id)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            return existingEmployee;
        }

        public Employee? UpdateEmployee(Guid id, Employee employee)
        {
            var ExistingEmployee = dbContext.Employees.Find(id);
            if (ExistingEmployee == null)
            {
                return null;
            }
            ExistingEmployee.Name = employee.Name;
            ExistingEmployee.Email = employee.Email;
            ExistingEmployee.PhoneNumber = employee.PhoneNumber;
            ExistingEmployee.Salary = employee.Salary;
            dbContext.SaveChanges();
            return ExistingEmployee;
        }
    }
}
