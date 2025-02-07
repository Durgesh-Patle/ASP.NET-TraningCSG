using Microsoft.AspNetCore.Mvc;
using SecoundWebApplication.Interface;
using SecoundWebApplication.Models;

namespace SecoundWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee) {
            employee = employee;
        }

        public async Task<IActionResult> Index()
        {
            return View(await employee.GetEmployeesAsync());
        }

        public IActionResult InsertEmploee()
        {
            return View();
        }

        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmploee([FromForm] Models.Employee emp)
        {
            ViewBag.Message = await employee.InsertEmployeeAsync(emp);
            return RedirectToAction("Index");
        }
    }
}
