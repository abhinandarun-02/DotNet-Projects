using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
