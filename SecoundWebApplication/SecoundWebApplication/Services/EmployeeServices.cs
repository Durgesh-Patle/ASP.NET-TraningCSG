using SecoundWebApplication.Interface;
using SecoundWebApplication.Models;

namespace SecoundWebApplication.Services
{
    public class EmployeeServices:IEmployee
    {
        private readonly string _connectionString;

        public EmployeeServices(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

         public Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();



        }


    }
}
