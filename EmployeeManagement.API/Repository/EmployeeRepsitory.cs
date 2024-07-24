using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repository
{
    public class EmployeeRepsitory : IEmployeeRepository
    {

        EmployeeDbContext _dbContext;

        public EmployeeRepsitory(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await GetEmployee(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await GetEmployee(id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
        }
            return true;
        }
    }
}
