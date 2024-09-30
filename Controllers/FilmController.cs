using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class FilmController : Controller
    {
        [Route("Film")]
        public IActionResult Film()
        {
            return View();
        }
    }
}
