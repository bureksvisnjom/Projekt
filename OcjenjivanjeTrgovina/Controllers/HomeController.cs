using Microsoft.AspNetCore.Mvc;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Početna";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "O Aplikaciji";
            return View();
        }
    }
}
