using System.Text.Json.Serialization;
using CRUDAppUsingASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDAppUsingASPCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7153/api/StudentAPI/";
        private HttpClient client=new HttpClient();


        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage responce=client.GetAsync(url).Result;

            if (responce.IsSuccessStatusCode) { 
                string result= responce.Content.ReadAsStringAsync().Result;
                var data=JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null) { 
                    students = data;
                }
            }
            return View(students);
        }
    }
}
