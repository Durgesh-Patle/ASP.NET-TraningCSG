using Microsoft.AspNetCore.Mvc;
using Registration_Form.Interface;
using Registration_Form.Models;

namespace Registration_Form.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers _users;

        public UserController(IUsers users)
        {
            _users = users;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _users.GetAllUsersAsync());
        }

        [HttpGet("InsertUser")]
        public IActionResult InsertUser()
        {
            return View();
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromForm] User user)
        {
            ViewBag.Message = await _users.InsertUserAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> Details(int id)
        {
            var user =await _users.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Message = await _users.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _users.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] User user)
        {
            ViewBag.Message = await _users.UpdateUserById(user);
            return RedirectToAction("Index");
        }
    }

}
