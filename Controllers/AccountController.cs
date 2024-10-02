using Microsoft.AspNetCore.Mvc;

namespace projekt1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
