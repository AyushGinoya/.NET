using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FillForm()
        {
            return View();
        }


        public IActionResult ShowData(User user)
        {
            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            ViewBag.Age = user.Age;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
