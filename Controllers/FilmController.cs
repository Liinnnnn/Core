using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class FilmController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
