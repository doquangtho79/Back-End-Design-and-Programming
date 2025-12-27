using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy() => View();
        public IActionResult Help() => View();
    }
}
