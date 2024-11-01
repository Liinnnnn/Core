using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Film()
        {
            return View();
        }
  
        public IActionResult AddFilm()
        {
            return View();
        }

    }
}
