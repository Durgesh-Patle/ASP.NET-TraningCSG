using SecoundWebApplication.Models;

namespace SecoundWebApplication.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<string> InsertEmployeeAsync(Employee emp);
    }
}
