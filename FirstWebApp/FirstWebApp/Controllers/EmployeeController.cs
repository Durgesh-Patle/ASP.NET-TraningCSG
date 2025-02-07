using FirstWebApp.Interface;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employees;

        public EmployeeController(IEmployee employees)
        {
            this.employees = employees;
        }

        public async Task<IActionResult> Index()
        {
            return View(await employees.GetEmployeesAsync());
        }

        [HttpGet("InsertEmployee")]
        public IActionResult InsertEmployee()
        {
            return View(new Employee());
        }


        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromForm] Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }
            ViewBag.Message = await employees.InsertEmployeeAsync(emp);
            return RedirectToAction("Index");
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> Details(int id)
        {
            var emp = await employees.GetEmployeeByIdAsync(id);
            return View(emp);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Message = await employees.DeleteEmployeByIdAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var emp = await employees.GetEmployeeByIdAsync(id);
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee emp)
        {
            ViewBag.Message = await employees.UpdateEmployeeById(emp);
            return RedirectToAction("Index");
        }

    }
}
