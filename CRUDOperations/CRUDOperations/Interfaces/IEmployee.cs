using CRUDOperations.Models;

namespace CRUDOperations.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<string> InsertEmployeeAsync(Employee emp);

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<string> DeleteEmployeByIdAsync(int id);

        Task<string> UpdateEmployeeById(Employee emp);
    }
}
