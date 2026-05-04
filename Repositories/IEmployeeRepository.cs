using EmployeePortal.Data.Domain;

namespace EmployeePortal.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee? GetById(Guid id);
        Employee CreateEmployee(Employee employee);
        Employee? UpdateEmployee(Guid id,Employee employee);

        Employee? DeleteEmployee(Guid id);
    }
}
