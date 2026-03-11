using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.CourseList = new SelectList(new List<string>
            {
                "IOT", "IT", "CE", "BCA", "MCA", "CHE"
            });

            return View();
        }
        [HttpPost]
        public IActionResult Register(Student Student)
        {
            if (ModelState.IsValid)
            {
                return View("ShowStudent", Student);
            }

            ViewBag.CourseList = new SelectList(new List<string>
            {
                "IOT", "IT", "CE", "BCA", "MCA", "CHE"
            });

            return View(Student);

        }

    }
}
