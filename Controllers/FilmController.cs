using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
