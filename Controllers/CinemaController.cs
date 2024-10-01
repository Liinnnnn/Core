using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
