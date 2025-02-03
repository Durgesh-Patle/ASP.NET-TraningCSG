using CRUDOperations.Interfaces;
using CRUDOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee) {
            _employee = employee;
        }

        [HttpGet("GetEmployee")]

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employee.GetEmployeesAsync();
        }

        [HttpPost("InsertEmployee")]

        public async Task<string> InsertEmployee([FromBody] Employee emp)
        {
            return await _employee.InsertEmployeeAsync(emp);
        }

        [HttpGet("GetEmployeeById/{id}")]

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employee.GetEmployeeByIdAsync(id);
        }

        [HttpDelete("DeleteEmployeeById/{id}")]

        public async Task<string> DeleteEmployeById(int id)
        {
            return await _employee.DeleteEmployeByIdAsync(id);
        }

        [HttpPut("UpdateEmployeeById")]

        public async Task<string> UpdateEmploye(Employee emp)
        {
            return await _employee.UpdateEmployeeById(emp);
        }

    }
}
