using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }
    }
}
